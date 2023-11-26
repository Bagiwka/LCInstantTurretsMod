using HarmonyLib;
using UnityEngine;
using System.Reflection;

namespace LCInstantFiring.Patches
{
    [HarmonyPatch(typeof(Turret))]
    internal class TurretPatch
    {
        private static FieldInfo turretIntervalField = typeof(Turret).GetField("turretInterval", BindingFlags.NonPublic | BindingFlags.Instance);

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void Postfix(Turret __instance)
        {
            // Access turretInterval using reflection
            float currentInterval = (float)turretIntervalField.GetValue(__instance);

            // Modify turretInterval if needed
            turretIntervalField.SetValue(__instance, 100f);
        }
    }
}
