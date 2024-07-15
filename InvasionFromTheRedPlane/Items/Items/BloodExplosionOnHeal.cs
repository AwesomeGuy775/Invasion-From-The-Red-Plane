using BepInEx;
using AwesomeGuy775.RedInvasion;
using R2API;
using RoR2;
using RoR2.Items;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AwesomeGuy775.RedInvasion.Items{
    public sealed class BloodExplosionOnHeal{
        //vars for item stats
        private static float maxTimeForActivation = 10f;
        private static float percentHealthForActivation = 10f/100f;

        //initilaize item
        public static void init(){
            //language Tokens do this later using this https://risk-of-thunder.github.io/R2Wiki/Mod-Creation/Assets/Localization/
            Items.bloodExplosionOnHeal.name = "BLOODEXPLOSIONONHEAL_NAME";

            //set item tier
            Items.bloodExplosionOnHeal._itemTierDef = Addressables.LoadAssetAsync<ItemTierDef>("RoR2/Base/Common/Tier2Def.asset").WaitForCompletion();

            //set item models CHANGE THESE TO ACTUAL MODELS WHEN WE HAVE THEM
            Items.bloodExplosionOnHeal.pickupIconSprite = Addressables.LoadAssetAsync<Sprite>("RoR2/Base/Common/MiscIcons/texMysteryIcon.png").WaitForCompletion();
            Items.bloodExplosionOnHeal.pickupModelPrefab = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Mystery/PickupMystery.prefab").WaitForCompletion();

            //set item properties
            Items.bloodExplosionOnHeal.canRemove = true; //can be taken my printer, shrine of order, etc
            Items.bloodExplosionOnHeal.hidden = false; //there will be a pickup notification
            Items.bloodExplosionOnHeal.tags = [ItemTag.Damage];

            //add item display rules later. for now these are null
            ItemDisplayRuleDict displayRules = new ItemDisplayRuleDict(null);

            //add item to R2API
            ItemAPI.Add(new CustomItem(Items.bloodExplosionOnHeal, displayRules));
        }
        
        public static void countHeal(float amount, float maxHealth, CharacterBody body){
            Buffs.Buffs.addStacksTimed(body, (int) System.Math.Round(amount), Buffs.Buffs.countHeal, maxTimeForActivation);
            while (body.GetBuffCount(Buffs.Buffs.countHeal.buffIndex)>=percentHealthForActivation*maxHealth){
                Buffs.Buffs.removeStacksTimed(body, (int) System.Math.Ceiling(percentHealthForActivation*maxHealth), Buffs.Buffs.countHeal);
                bloodExplode();
            }
        }

        public static void bloodExplode(){
            
        }
    }  
}
