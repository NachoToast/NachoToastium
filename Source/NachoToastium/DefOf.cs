using RimWorld;
using Verse;

namespace NachoToastium
{
    [DefOf]
    public static class HediffDefOf
    {
        [MayRequireRoyalty]
        public static HediffDef NachoToastium_Branded;

        [MayRequireRoyalty]
        public static HediffDef NachoToastium_Engraved;

        [MayRequireRoyalty]
        public static HediffDef NachoToastium_EngravedElectric;

        public static HediffDef NachoToastium_BehaviouralChipA;
        public static HediffDef NachoToastium_BehaviouralChipB;

        static HediffDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(HediffDefOf));
        }
    }

    [DefOf]
    public static class ThoughtDefOf
    {
        [MayRequireRoyalty]
        public static ThoughtDef NachoToastium_Branded;

        static ThoughtDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThoughtDefOf));
        }
    }
}