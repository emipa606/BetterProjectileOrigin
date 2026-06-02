using HarmonyLib;
using UnityEngine;
using Verse;

namespace BetterProjectileOrigin;

[HarmonyPatch(typeof(Projectile), "Launch", typeof(Thing), typeof(Vector3), typeof(LocalTargetInfo),
    typeof(LocalTargetInfo), typeof(ProjectileHitFlags), typeof(bool), typeof(Thing), typeof(ThingDef))]
public class Projectile_Launch
{
    [HarmonyPostfix]
    public static void Prefix(ref Vector3 origin, Thing launcher, Thing equipment)
    {
        var offset = BetterProjectileOrigin.GetProjectileOffset(launcher, equipment, out var weaponPosition);

        if (offset == Vector3.zero)
        {
            return;
        }

        BetterProjectileOrigin.LogMessage(
            $"Replacing origin from {origin} to {weaponPosition} for held weapon {equipment} ({equipment.DrawPos}) by {launcher} ({launcher.DrawPos}) and then adding offset {offset}");

        origin = weaponPosition + offset;
    }
}