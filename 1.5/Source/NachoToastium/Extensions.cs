using Verse;

namespace NachoToastium
{
    public static class Extensions
    {
        public static bool HasBehaviouralChip(this Pawn pawn)
        {
            if (pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.NachoToastium_BehaviouralChipA) != null)
            {
                return true;
            }

            if (pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.NachoToastium_BehaviouralChipB) != null)
            {
                return true;
            }

            return false;
        }
    }
}