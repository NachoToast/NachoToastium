using System.Collections.Generic;
using Verse;

namespace NachoToastium
{
    public static class Extensions
    {
        private static readonly HashSet<HediffDef> BrandedHediffs = new HashSet<HediffDef>
        {
            HediffDefOf.NachoToastium_Branded,
            HediffDefOf.NachoToastium_Engraved,
            HediffDefOf.NachoToastium_EngravedElectric,
        };

        private static readonly HashSet<HediffDef> BehaviouralChipHediffs = new HashSet<HediffDef>
        {
            HediffDefOf.NachoToastium_BehaviouralChipA,
            HediffDefOf.NachoToastium_BehaviouralChipB,
        };

        public static bool IsBranded(this Pawn pawn)
        {
            if (!ModsConfig.RoyaltyActive)
            {
                return false;
            }

            if (pawn.health?.hediffSet?.hediffs == null)
            {
                return false;
            }

            foreach (Hediff hediff in pawn.health.hediffSet.hediffs)
            {
                if (BrandedHediffs.Contains(hediff.def))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool HasBehaviouralChip(this Pawn pawn)
        {
            foreach (Hediff hediff in pawn.health.hediffSet.hediffs)
            {
                if (BehaviouralChipHediffs.Contains(hediff.def))
                {
                    return true;
                }
            }

            return false;
        }
    }
}