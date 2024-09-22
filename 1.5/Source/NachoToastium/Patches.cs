using HarmonyLib;
using RimWorld;
using Verse;

namespace NachoToastium
{
    [StaticConstructorOnStartup]
    internal static class Patches
    {
        static Patches()
        {
            Harmony harmony = new Harmony("NachoToast.NachoToastium");

            harmony.Patch(
                original: AccessTools.Method(
                    type: typeof(SlaveRebellionUtility),
                    name: nameof(SlaveRebellionUtility.CanParticipateInSlaveRebellion)),
                postfix: new HarmonyMethod(
                    methodType: typeof(Patches),
                    methodName: nameof(CanParticipateInX_Postfix)));

            harmony.Patch(
                original: AccessTools.Method(
                    type: typeof(PrisonBreakUtility),
                    name: nameof(PrisonBreakUtility.CanParticipateInPrisonBreak)),
                postfix: new HarmonyMethod(
                    methodType: typeof(Patches),
                    methodName: nameof(CanParticipateInX_Postfix)));

            harmony.Patch(
                original: AccessTools.Method(
                    type: typeof(Pawn_GuestTracker),
                    name: nameof(Pawn_GuestTracker.SetGuestStatus)),
                postfix: new HarmonyMethod(
                    methodType: typeof(Patches),
                    methodName: nameof(SetGuestStatus_Postfix)));
        }

        /// <summary>
        /// Accounts for behavioural chips when slave rebelling or prison breaking.
        /// </summary>
        private static void CanParticipateInX_Postfix(ref bool __result, Pawn pawn)
        {
            if (__result == false)
            {
                // Not participating already, no need to check for a behavioural chip.
                return;
            }

            if (pawn.HasBehaviouralChip())
            {
                // Has a behavioural chip, so shouldn't rebel.
                __result = false;
            }
        }

        /// <summary>
        /// Accounts for behavioural chips when enslaving a pawn.
        /// </summary>
        private static void SetGuestStatus_Postfix(Pawn_GuestTracker __instance, Pawn ___pawn, GuestStatus guestStatus)
        {
            if (guestStatus != GuestStatus.Slave)
            {
                // Not enslaving, so don't bother changing interaction mode.
                return;
            }

            if (__instance.slaveInteractionMode == SlaveInteractionModeDefOf.Suppress && ___pawn.HasBehaviouralChip())
            {
                // Set to suppression but isn't needed due to behavioural chip, so change back to no interaction.
                __instance.slaveInteractionMode = SlaveInteractionModeDefOf.NoInteraction;
            }
        }
    }
}