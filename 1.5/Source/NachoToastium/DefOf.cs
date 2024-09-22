using RimWorld;
using Verse;

namespace NachoToastium
{
    [DefOf]
    public static class HediffDefOf
    {
        public static HediffDef NachoToastium_Branded;
        public static HediffDef NachoToastium_Engraved;
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
        public static ThoughtDef NachoToastium_Branded;

        static ThoughtDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThoughtDefOf));
        }
    }
}