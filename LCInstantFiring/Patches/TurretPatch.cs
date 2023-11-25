using HarmonyLib;

[HarmonyPatch(typeof(Turret))]
[HarmonyPatch("Update")]
class TurretPatch
{
    static void Postfix(Turret __instance, ref float _turretInterval)
    {
        if (__instance.turretActive && __instance.turretMode == TurretMode.Detection)
        {
            if (_turretInterval >= 1.5f)
            {
                SetTurretMode(__instance, TurretMode.Firing);
            }
        }
    }

    static void SetTurretMode(Turret turret, TurretMode mode)
    {
        turret.turretMode = mode;
        turret.SetToModeClientRpc((int)mode);
    }
}
