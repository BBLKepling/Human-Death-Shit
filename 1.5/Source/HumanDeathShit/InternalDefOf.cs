using RimWorld;
using Verse;

namespace HumanDeathShit
{
    [DefOf]
    public static class InternalDefOf
    {
        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }

        public static EffecterDef BBLK_Fecal;
        public static SoundDef BBLK_Defecate;
    }
}
