using BepInEx;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace InvasionFromTheRedPlane
{
    [BepInPlugin("com.AwesomeGuy775.Invasion-From-The-Red-Plane", "Invasion From The Red Plane", "0.0.0")]
    [BepInProcess("Risk of Rain 2.exe")]
    [BepInDependency(ItemAPI.PluginGUID)]
    [BepInDependency(LanguageAPI.PluginGUID)]
    public class RedInvasion : BaseUnityPlugin
    {
        private void Awake()
        {
            //plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
