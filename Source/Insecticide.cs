using RimWorld;
using Verse;

namespace Insecticide
{
    public class DamageWorker_AddBugInjury : DamageWorker_AddGlobal
    {
        
        public override DamageResult Apply(DamageInfo dinfo, Thing thing)
        {
            Pawn pawn = thing as Pawn;
            if (pawn != null)
            {
                Hediff hediff = HediffMaker.MakeHediff(dinfo.Def.hediff, pawn, (BodyPartRecord) null);
                hediff.Severity = Rand.Range(.01f, pawn.RaceProps.FleshType == FleshTypeDefOf.Insectoid ? 1f : 0.05f);
                pawn.health.AddHediff(hediff, (BodyPartRecord) null, new DamageInfo?(dinfo), (DamageWorker.DamageResult) null);
            }
            return new DamageWorker.DamageResult();
        }
    }
}