namespace NoScanner.Harmony;

using HarmonyLib;
using JetBrains.Annotations;

[HarmonyPatch(typeof(HUDManager), "CanPlayerScan")]
internal static class PreventPlayerFromScanning_Patch
{
    [UsedImplicitly]
    [HarmonyPrefix]
    private static bool OnCanPlayerScan(ref bool __result) => __result = false;
}