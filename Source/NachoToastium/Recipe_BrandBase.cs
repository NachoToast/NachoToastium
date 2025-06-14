using RimWorld;
using System.Collections.Generic;
using Verse;

namespace NachoToastium
{
    public class Recipe_BrandBase : RecipeWorker
    {
        public override IEnumerable<BodyPartRecord> GetPartsToApplyOn(Pawn pawn, RecipeDef recipe)
        {
            if (pawn.IsBranded())
            {
                yield break;
            }

            yield return pawn.RaceProps?.body?.corePart;
        }

        public override void ApplyOnPawn(
            Pawn pawn,
            BodyPartRecord part,
            Pawn billDoer,
            List<Thing> ingredients,
            Bill bill)
        {
            pawn.health?.AddHediff(recipe.addsHediff, part);

            pawn.needs?.mood?.thoughts?.memories?.TryGainMemory(
                ThoughtDefOf.NachoToastium_Branded,
                billDoer);
        }
    }
}