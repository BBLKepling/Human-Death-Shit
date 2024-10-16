using DubsBadHygiene;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.Sound;

namespace HumanDeathShit
{
    [HarmonyPatch]
    public class CompRottable_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(CompRottable __instance)
        {
            if (!DeathShit_Settings.corpseShit || 
                !(__instance.parent is Corpse corpse) ||
                corpse.Map == null || 
                __instance.Stage != RotStage.Rotting ||
                !(corpse.InnerPawn?.RaceProps is RaceProperties raceProps) ||
                (!DeathShit_Settings.deathShitHuman && raceProps.Humanlike) ||
                (!DeathShit_Settings.deathShitAnimal && raceProps.Animal) ||
                (!DeathShit_Settings.deathShitDryad && raceProps.Dryad) ||
                (!DeathShit_Settings.deathShitInsect && raceProps.Insect) ||
                (!DeathShit_Settings.deathShitMechanoid && raceProps.IsMechanoid)) return;
            if (DeathShit_Settings.deathShitSND) InternalDefOf.BBLK_Defecate.PlayOneShot(new TargetInfo(corpse.Position, corpse.Map));
            if (DeathShit_Settings.deathShitSpray) InternalDefOf.BBLK_Fecal.Spawn(corpse, corpse.Map);
            corpse.Map.GetComponent<MapComponent_Hygiene>().SewageGrid.AddAt(corpse.Position, 10f);
            FilthMaker.TryMakeFilth(corpse.Position, corpse.Map, DubDef.FilthFaeces, corpse.InnerPawn.LabelIndefinite());
        }
    }
}
