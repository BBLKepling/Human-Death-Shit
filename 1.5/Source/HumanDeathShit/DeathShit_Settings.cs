using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace HumanDeathShit
{
    internal class DeathShit_Settings : ModSettings
    {
        public static bool deathShitSND = true;
        public static bool deathShitSpray = true;
        public override void ExposeData()
        {
            Scribe_Values.Look(ref deathShitSND, "deathShitSND", true);
            Scribe_Values.Look(ref deathShitSpray, "deathShitSpray", true);
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
            listingStandard.CheckboxLabeled("BBLK_deathShitSND_Label".Translate(), ref DeathShit_Settings.deathShitSND, "BBLK_deathShitSND_ToolTip".Translate());
            listingStandard.CheckboxLabeled("BBLK_deathShitSpray_Label".Translate(), ref DeathShit_Settings.deathShitSpray, "BBLK_deathShitSpray_ToolTip".Translate());
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }
        public override string SettingsCategory() => "BBLK_DeathShitSettings".Translate();
    }
}
