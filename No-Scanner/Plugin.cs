namespace NoScanner;

using System.Reflection;
using BepInEx;
using PluginInfo = Dawn.LC.NoScanner.PluginInfo;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
internal sealed class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        HarmonyLib.Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
        Logger.LogInfo($"Checking in ;)");
    }
}