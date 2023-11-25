using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace LCInstantTurrets
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class LCInstantTurretsBase : BaseUnityPlugin
    {

        private const string modGUID = "Bagiwka.LCInstantTurrets";
        private const string modName = "LCInstantTurrets";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static LCInstantTurretsBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {

            Logger.LogInfo("Time to get shot.");
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("Get your legs ready!");

            harmony.PatchAll(typeof(LCInstantTurretsBase));
            harmony.PatchAll(typeof(TurretPatch));


        }

    }
}
