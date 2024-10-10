using HarmonyLib;
using RimWorld;
using Verse;

namespace HumanDeathShit
{
    [StaticConstructorOnStartup]
    public static class HarmonyInit
    {
        static HarmonyInit()
        {
            Harmony harmonyInstance = new Harmony("BBLKepling.HumanDeathShit");
            var deathFix = typeof(DeathActionWorker_DeathShit_Patch).GetMethod("Postfix");
            var corpseFix = typeof(CompRottable_Patch).GetMethod("Postfix");

            var simple = typeof(DeathActionWorker_Simple).GetMethod("PawnDied");
            harmonyInstance.Patch(simple, postfix: new HarmonyMethod(deathFix));

            var smallEx = typeof(DeathActionWorker_SmallExplosion).GetMethod("PawnDied");
            harmonyInstance.Patch(smallEx, postfix: new HarmonyMethod(deathFix));

            var bigEx = typeof(DeathActionWorker_BigExplosion).GetMethod("PawnDied");
            harmonyInstance.Patch(bigEx, postfix: new HarmonyMethod(deathFix));

            var tox = typeof(DeathActionWorker_ToxCloud).GetMethod("PawnDied");
            harmonyInstance.Patch(tox, postfix: new HarmonyMethod(deathFix));

            var rot = AccessTools.Method(typeof(CompRottable), "StageChanged");
            harmonyInstance.Patch(rot, postfix: new HarmonyMethod(corpseFix));
        }
    }
}
