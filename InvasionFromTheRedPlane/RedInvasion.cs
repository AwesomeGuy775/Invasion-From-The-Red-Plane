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
            OnEnable();
            //initialize items
            BloodExplosionOnHeal.init(); 
            //print that plugin is loaded
            Logger.LogInfo($"Plugin modName is loaded!");
        }

        //IM HOOKING!!!!!
        private void OnEnable(){
            On.RoR2.HealthComponent.Heal += OnHeal;
        }
        private void OnDisable(){
            On.RoR2.HealthComponent.Heal -= OnHeal;
        }

        private float OnHeal(On.RoR2.HealthComponent.orig_Heal orig, HealthComponent self, float amount, ProcChainMask procChainMask, bool nonRegen){
            float healedAmount = orig(self, amount, procChainMask, nonRegen);
            if (self.body && self.body.isPlayerControlled){
                BloodExplosionOnHeal.countHeal(healedAmount);
            }
            return healedAmount;
        }
    }
}
