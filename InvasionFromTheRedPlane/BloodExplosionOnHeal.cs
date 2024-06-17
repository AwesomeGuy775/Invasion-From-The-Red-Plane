using BepInEx;
using AwesomeGuy775.RedInvasion;
using R2API;
using RoR2;
using RoR2.Items;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AwesomeGuy775.RedInvasion.Items{
    public sealed class BloodExplosionOnHeal{

        //Declare
        public static ItemDef bloodExplosionOnHeal;
        //vars for items
        private static float maxTimeForActivation = 5f;
        private static float percentHealthForActivation = 10f/100f;
        //Declare vars for healing logic
        private static float accumulatedHeal = 0f;
        private static float accumulatedTime = 0f;
        private static float lastHealTime = -1f;
        private static float currTime;
        

        //initilaize item
        public static void init(){
            //define crimson relic
            bloodExplosionOnHeal = ScriptableObject.CreateInstance<ItemDef>();
            //language Tokens
            //do this later using this https://risk-of-thunder.github.io/R2Wiki/Mod-Creation/Assets/Localization/
            //lang tokens go here
            bloodExplosionOnHeal.name = "BLOODEXPLOSIONONHEAL_NAME";
            //set item tier
#pragma warning disable Publicizer001
            bloodExplosionOnHeal._itemTierDef = Addressables.LoadAssetAsync<ItemTierDef>("RoR2/Base/Common/Tier2Def.asset").WaitForCompletion();
#pragma warning restore Publicizer001
            //set item models CHANGE THESE TO ACTUAL MODELS WHEN WE HAVE THEM
            bloodExplosionOnHeal.pickupIconSprite = Addressables.LoadAssetAsync<Sprite>("RoR2/Base/Common/MiscIcons/texMysteryIcon.png").WaitForCompletion();
            bloodExplosionOnHeal.pickupModelPrefab = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Mystery/PickupMystery.prefab").WaitForCompletion();
            //set item properties
            bloodExplosionOnHeal.canRemove = true; //can be taken my printer, shrine of order, etc
            bloodExplosionOnHeal.hidden = false; //there will be a pickup notification
            bloodExplosionOnHeal.tags = new ItemTag[]{
                ItemTag.Damage
            };
            //add item display rules later. for now these are null
            ItemDisplayRuleDict bloodExplosionOnHealDisplayRules = new ItemDisplayRuleDict(null);
            //add item to R2API
            ItemAPI.Add(new CustomItem(bloodExplosionOnHeal, bloodExplosionOnHealDisplayRules));
        }
        
        public static void countHeal(float amount, float maxHealth){
            currTime = Time.time;
            if (lastHealTime == -1f){
                lastHealTime = currTime;
            }
            accumulatedTime = currTime - lastHealTime;
            if (accumulatedTime > maxTimeForActivation){
                accumulatedTime = 0f;
                lastHealTime = currTime;
                accumulatedHeal = 0f;
            }
            accumulatedHeal += amount;
            if (accumulatedHeal >= percentHealthForActivation*maxHealth){
                bloodExplode();
                accumulatedTime = 0f;
                lastHealTime = -1f;
                accumulatedHeal = 0f;
            } 
        }
        public static void bloodExplode(){
            
        }
    }  
}
