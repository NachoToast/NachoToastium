namespace NachoToastium;

public static class Extensions
{
    private static readonly HashSet<HediffDef> BehaviouralChipHediffs =
    [
        HediffDefOf.NachoToastium_BehaviouralChipA,
        HediffDefOf.NachoToastium_BehaviouralChipB,
    ];

    private static readonly HashSet<HediffDef> BrandedHediffs =
    [
        HediffDefOf.NachoToastium_Branded,
        HediffDefOf.NachoToastium_Engraved,
        HediffDefOf.NachoToastium_EngravedElectric,
    ];

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
}
