using UnityEngine;
using Verse;

namespace HumanDeathShit
{
    public class DeathShit_Settings : ModSettings
    {
        public static bool deathShit = true;
        public static bool corpseShit = true;

        public static bool deathShitSND = true;
        public static bool deathShitSpray = true;
        public static bool deathShitHuman = true;
        public static bool deathShitAnimal = false;
        public static bool deathShitDryad = false;
        public static bool deathShitInsect = false;
        public static bool deathShitMechanoid = false;
        public override void ExposeData()
        {
            Scribe_Values.Look(ref deathShit, "deathShit", true);
            Scribe_Values.Look(ref corpseShit, "corpseShit", true);

            Scribe_Values.Look(ref deathShitSND, "deathShitSND", true);
            Scribe_Values.Look(ref deathShitSpray, "deathShitSpray", true);
            Scribe_Values.Look(ref deathShitHuman, "deathShitHuman", true);
            Scribe_Values.Look(ref deathShitAnimal, "deathShitAnimal", false);
            Scribe_Values.Look(ref deathShitDryad, "deathShitDryad", false);
            Scribe_Values.Look(ref deathShitInsect, "deathShitInsect", false);
            Scribe_Values.Look(ref deathShitMechanoid, "deathShitMechanoid", false);
            base.ExposeData();
        }
    }
    public class HeyListenMod : Mod
    {
        public HeyListenMod(ModContentPack content) : base(content)
        {
            GetSettings<DeathShit_Settings>();
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.CheckboxLabeled("BBLK_deathShit_Label".Translate(), ref DeathShit_Settings.deathShit, "BBLK_deathShit_ToolTip".Translate());
            listingStandard.CheckboxLabeled("BBLK_corpseShit_Label".Translate(), ref DeathShit_Settings.corpseShit, "BBLK_corpseShit_ToolTip".Translate());

            listingStandard.CheckboxLabeled("BBLK_deathShitSND_Label".Translate(), ref DeathShit_Settings.deathShitSND, "BBLK_deathShitSND_ToolTip".Translate());
            listingStandard.CheckboxLabeled("BBLK_deathShitSpray_Label".Translate(), ref DeathShit_Settings.deathShitSpray, "BBLK_deathShitSpray_ToolTip".Translate());
            listingStandard.CheckboxLabeled("BBLK_deathShitHuman_Label".Translate(), ref DeathShit_Settings.deathShitHuman, "BBLK_deathShitHuman_ToolTip".Translate());
            listingStandard.CheckboxLabeled("BBLK_deathShitAnimal_Label".Translate(), ref DeathShit_Settings.deathShitAnimal, "BBLK_deathShitAnimal_ToolTip".Translate());
            listingStandard.CheckboxLabeled("BBLK_deathShitDryad_Label".Translate(), ref DeathShit_Settings.deathShitDryad, "BBLK_deathShitDryad_ToolTip".Translate());
            listingStandard.CheckboxLabeled("BBLK_deathShitInsect_Label".Translate(), ref DeathShit_Settings.deathShitInsect, "BBLK_deathShitInsect_ToolTip".Translate());
            listingStandard.CheckboxLabeled("BBLK_deathShitMechanoid_Label".Translate(), ref DeathShit_Settings.deathShitMechanoid, "BBLK_deathShitMechanoid_ToolTip".Translate());
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }
        public override string SettingsCategory() => "BBLK_DeathShitSettings".Translate();
    }
}
