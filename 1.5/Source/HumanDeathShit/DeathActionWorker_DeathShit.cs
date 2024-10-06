using DubsBadHygiene;
using RimWorld;
using Verse;
using Verse.AI.Group;
using Verse.Sound;

namespace HumanDeathShit
{
    public class DeathActionWorker_DeathShit : DeathActionWorker
    {
        public override void PawnDied(Corpse corpse, Lord prevLord)
        {
            if (DeathShit_Settings.deathShitSND) InternalDefOf.BBLK_Defecate.PlayOneShot(new TargetInfo(corpse.Position, corpse.Map));
            if (DeathShit_Settings.deathShitSpray) InternalDefOf.BBLK_Fecal.Spawn(corpse, corpse.Map);
            FilthMaker.TryMakeFilth(corpse.Position, corpse.Map, DubDef.FilthFaeces);
        }
    }
}
