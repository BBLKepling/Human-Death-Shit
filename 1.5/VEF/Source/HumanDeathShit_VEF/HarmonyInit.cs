using AnimalBehaviours;
using HarmonyLib;
using HumanDeathShit;
using Verse;

namespace HumanDeathShit_VEF
{
    [StaticConstructorOnStartup]
    public static class HarmonyInit
    {
        static HarmonyInit()
        {
            Harmony harmonyInstance = new Harmony("BBLKepling.HumanDeathShit_VEF");
            var postfix = typeof(DeathActionWorker_DeathShit_Patch).GetMethod("Postfix");

            var drop = typeof(DeathActionWorker_DropOnDeath).GetMethod("PawnDied");
            harmonyInstance.Patch(drop, postfix: new HarmonyMethod(postfix));

            var conEx = typeof(DeathActionWorker_ConfigurableExplosion).GetMethod("PawnDied");
            harmonyInstance.Patch(conEx, postfix: new HarmonyMethod(postfix));
        }
    }
}
