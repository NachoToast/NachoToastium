namespace NachoToastium;

[DefOf]
public static class HediffDefOf
{
    public static HediffDef NachoToastium_BehaviouralChipA;

    public static HediffDef NachoToastium_BehaviouralChipB;

    [MayRequireRoyalty]
    public static HediffDef NachoToastium_Branded;

    [MayRequireRoyalty]
    public static HediffDef NachoToastium_Engraved;

    [MayRequireRoyalty]
    public static HediffDef NachoToastium_EngravedElectric;

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
