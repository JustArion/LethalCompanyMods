namespace NoScanner.Harmony;

using System;
using HarmonyLib;
using JetBrains.Annotations;

[HarmonyPatch(typeof(HUDManager), "CanPlayerScan")]
internal static class PreventPlayerFromScanning_Patch
{
    private static bool _loggedErrorOnce;
    private static bool _isInShip => GameNetworkManager.Instance.localPlayerController.isInElevator;
    
    [UsedImplicitly]
    [HarmonyPrefix]
    private static bool OnCanPlayerScan(ref bool __result)
    {
        try
        {
            if (Plugin.DisableOnlyInShip.Value)
                return !_isInShip;

            return __result = false;
        }
        catch (Exception e)
        {
            if (_loggedErrorOnce) 
                return true;
            
            Plugin.ModLogger.LogError(e);
            _loggedErrorOnce = true;
            return true;
        }

    }
}