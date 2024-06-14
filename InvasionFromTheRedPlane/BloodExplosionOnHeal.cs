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
        private static ItemDef bloodExplosionOnHeal;

        //initilaize item
        public static void init(){
            //define crimson relic
            bloodExplosionOnHeal = ScriptableObject.CreateInstance<ItemDef>();
            //language Tokens
            //do this later using this https://risk-of-thunder.github.io/R2Wiki/Mod-Creation/Assets/Localization/
            //lang tokens go here
            bloodExplosionOnHeal.nameToken = "BLOODEXPLOSIONONHEAL_NAME";
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
            var bloodExplosionOnHealDisplayRules = new ItemDisplayRuleDict(null);
            //add item to R2API
            var bloodExplosionOnHealIndex = ItemAPI.Add(new CustomItem(bloodExplosionOnHeal, bloodExplosionOnHealDisplayRules));
        }

        public static void countHeal(float amount){
            
        }
    }  
}
