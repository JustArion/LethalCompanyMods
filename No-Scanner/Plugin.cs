namespace NoScanner;

using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using PluginInfo = Dawn.LC.NoScanner.PluginInfo;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
internal sealed class Plugin : BaseUnityPlugin
{
    public static ManualLogSource ModLogger { get; private set; }

    public static ConfigEntry<bool> DisableOnlyInShip;
    private void Awake()
    {
        ModLogger = Logger;
        HarmonyLib.Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
        DisableOnlyInShip = Config.Bind("NoScanner", "DisableOnlyInShip", false, "Disables the use of the Scanner in the ship, everywhere else it's allowed");
        Logger.LogInfo("Checking in ;)");
    }
}