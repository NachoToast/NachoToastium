using RimWorld;
using System.Collections.Generic;
using Verse;

namespace NachoToastium
{
    public class Recipe_BrandBase : RecipeWorker
    {
        private static readonly List<HediffDef> brandedHediffsFamily = new List<HediffDef>
        {
            HediffDefOf.NachoToastium_Branded,
            HediffDefOf.NachoToastium_Engraved,
            HediffDefOf.NachoToastium_EngravedElectric,
        };

        private static bool IsAlreadyBranded(HediffSet hediffSet)
        {
            foreach (HediffDef hediffDef in brandedHediffsFamily)
            {
                if (hediffSet.HasHediff(hediffDef)) return true;
            }

            return false;

        }

        public override IEnumerable<BodyPartRecord> GetPartsToApplyOn(Pawn pawn, RecipeDef recipe)
        {
            if (IsAlreadyBranded(pawn.health.hediffSet))
            {
                yield break;
            }

            yield return pawn.RaceProps.body.corePart;
        }

        public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients, Bill bill)
        {
            pawn.health.AddHediff(recipe.addsHediff, part);
            pawn.needs.mood.thoughts.memories.TryGainMemory(ThoughtDefOf.NachoToastium_Branded, billDoer);
        }
    }
}
