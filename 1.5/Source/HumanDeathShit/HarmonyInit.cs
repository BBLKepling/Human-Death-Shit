using HarmonyLib;
using RimWorld;
using System.Linq;
using System.Reflection;
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
            foreach (Assembly assembly in AccessTools.AllAssemblies())
            {
                foreach (MethodBase method in AccessTools.GetTypesFromAssembly(assembly)
                    .SelectMany(type => type.GetMethods())
                    .Where(method => method.DeclaringType.Name.StartsWith("DeathActionWorker") && method.Name.Equals("PawnDied") && !method.DeclaringType.IsAbstract)
                    .Cast<MethodBase>())
                {
                    harmonyInstance.Patch(method, postfix: new HarmonyMethod(deathFix));
                }
            }

            var corpseFix = typeof(CompRottable_Patch).GetMethod("Postfix");
            var rot = AccessTools.Method(typeof(CompRottable), "StageChanged");
            harmonyInstance.Patch(rot, postfix: new HarmonyMethod(corpseFix));
        }
    }
}
