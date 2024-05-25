using BepInEx;

namespace InvasionFromTheRedPlane
{
    [BepInPlugin("com.AwesomeGuy775.Invasion-From-The-Red-Plane", "Invasion From The Red Plane", "0.0.0")]
    [BepInProcess("Risk of Rain 2.exe")]
    public class RedInvasion : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
