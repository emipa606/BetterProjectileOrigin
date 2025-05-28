using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace BetterProjectileOrigin;

[HarmonyPatch]
[HarmonyPriority(Priority.High)]
public class PawnRenderUtility_DrawEquipmentAiming
{
    private static bool alreadyPatched;

    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return typeof(PawnRenderUtility).GetMethod("DrawEquipmentAiming");

        if (alreadyPatched)
        {
            yield break;
        }

        var dualWieldClass = AccessTools.TypeByName("DualWield.Harmony.PawnRenderer_DrawEquipmentAiming");
        if (dualWieldClass != null)
        {
            yield return AccessTools.Method(dualWieldClass, "DrawEquipmentAimingOverride");
            BetterProjectileOrigin.LogMessage("Adding support for Dual Wield", true);
        }

        alreadyPatched = true;
    }

    public static void Prefix(ref Thing eq, Vector3 drawLoc, float aimAngle)
    {
        BetterProjectileOrigin.WeaponPositions[eq] = new Tuple<Vector3, float>(drawLoc, aimAngle);
    }
}