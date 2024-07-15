using AwesomeGuy775.RedInvasion.Buffs;
using AwesomeGuy775.RedInvasion.Items;
using BepInEx;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AwesomeGuy775.RedInvasion{
    [BepInPlugin(guid, modName, version)]
    [BepInProcess("Risk of Rain 2.exe")]
    [BepInDependency(ItemAPI.PluginGUID)]
    [BepInDependency(LanguageAPI.PluginGUID)]
    public class RedInvasion : BaseUnityPlugin{
        internal const string guid = "com.AwesomeGuy775.Invasion-From-The-Red-Plane";
        internal const string modName = "Invasion From The Red Plane";
        internal const string version = "0.0.0";
        public void Awake(){
            //create hooks
            createHooks();
            //initialize
            initAll();
            //print that plugin is loaded
            Logger.LogInfo($"Plugin {modName} is loaded!");
        }

        //IM HOOKING!!!!!
        private void createHooks(){
            On.RoR2.HealthComponent.Heal += Hooks.OnHeal;
        }
        private void destroyHooks(){
            On.RoR2.HealthComponent.Heal -= Hooks.OnHeal;
        }

        private void initAll(){
            //init items
            BloodExplosionOnHeal.init();

            //init buffs
            CountHeal.init();
        }
    }
}
