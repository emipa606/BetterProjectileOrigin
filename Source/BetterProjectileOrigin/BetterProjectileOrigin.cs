using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace BetterProjectileOrigin;

[StaticConstructorOnStartup]
public static class BetterProjectileOrigin
{
    private static readonly Dictionary<ThingDef, Tuple<float, float>> WeaponOffsets;
    private static readonly object WeaponOffsetsLock = new();

    public static readonly Dictionary<Thing, Tuple<Vector3, float>> WeaponPositions;
    private static readonly object WeaponPositionsLock = new();

    static BetterProjectileOrigin()
    {
        WeaponOffsets = new Dictionary<ThingDef, Tuple<float, float>>();
        WeaponPositions = new Dictionary<Thing, Tuple<Vector3, float>>();
        var harmony = new Harmony("Mlie.BetterProjectileOrigin");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }

    public static Vector3 GetProjectileOffset(Thing equipment)
    {
        if (equipment == null)
        {
            LogMessage("No weapon is used");
            return Vector3.zero;
        }

        lock (WeaponPositionsLock)
        {
            if (!WeaponPositions.ContainsKey(equipment))
            {
                LogMessage("No weapon-position found");
                return Vector3.zero;
            }
        }

        // Lazy-load the offset if not already cached
        lock (WeaponOffsetsLock)
        {
            if (!WeaponOffsets.ContainsKey(equipment.def))
            {
                LogMessage($"Offset for weapon {equipment} ({equipment.def}) not cached, calculating now.");
                cacheWeaponOffset(equipment.def);

                // If still not available (e.g., missing graphics), return zero
                if (!WeaponOffsets.ContainsKey(equipment.def))
                {
                    LogMessage($"Weapon {equipment} ({equipment.def}) has no offset after calculation");
                    return Vector3.zero;
                }
            }
        }

        float rotation;
        lock (WeaponPositionsLock)
        {
            rotation = WeaponPositions[equipment].Item2;
        }

        Vector3 offset;
        lock (WeaponOffsetsLock)
        {
            offset = rotation is > 200f and < 340f
                ? new Vector3(WeaponOffsets[equipment.def].Item1, 0, WeaponOffsets[equipment.def].Item2 * -1)
                : new Vector3(WeaponOffsets[equipment.def].Item1, 0, WeaponOffsets[equipment.def].Item2);
        }

        LogMessage($"Returning offset {offset} with rotation {rotation} for held weapon {equipment}");
        return offset.RotatedBy(rotation).RotatedBy(-90);
    }

    public static void LogMessage(string message, bool force = false)
    {
        if (!force && !BetterProjectileOriginMod.Instance.Settings.VerboseLogging)
        {
            return;
        }

        Log.Message($"[BetterProjectileOrigin]: {message}");
    }

    private static void cacheWeaponOffset(ThingDef weapon)
    {
        if (weapon.graphicData?.Graphic?.MatSingle?.mainTexture == null)
        {
            LogMessage($"Weapon {weapon} is missing graphic data.", true);
            return;
        }

        var texture = weapon.graphicData.Graphic.MatSingle.mainTexture;

        var renderTexture = RenderTexture.GetTemporary(
            texture.width,
            texture.height,
            0,
            RenderTextureFormat.Default,
            RenderTextureReadWrite.Linear);
        Graphics.Blit(texture, renderTexture);
        var previous = RenderTexture.active;
        RenderTexture.active = renderTexture;
        var icon = new Texture2D(texture.width, texture.height);
        icon.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        icon.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTexture);


        var pixels = icon.GetPixels32();
        var width = icon.width;
        var endPixel = new Vector2(0, 0);

        for (var i = 0; i < icon.height; i++)
        {
            for (var j = width - 1; j >= endPixel.x; j--)
            {
                if (pixels[j + (i * width)].a < 5)
                {
                    continue;
                }

                endPixel = new Vector2(j, i);
                break;
            }
        }

        var widthFactor = ((endPixel.x / width) - 0.5f) * 2;
        var heightFactor = (endPixel.y / icon.height) - 0.5f;

        LogMessage(
            $"Found endpixel {endPixel} of width {width} ({widthFactor}%) and height {icon.height} for {weapon} ({heightFactor}%) with drawSize {weapon.graphicData.drawSize}");


        lock (WeaponOffsetsLock)
        {
            WeaponOffsets[weapon] = new Tuple<float, float>(widthFactor, heightFactor);
        }
    }
}