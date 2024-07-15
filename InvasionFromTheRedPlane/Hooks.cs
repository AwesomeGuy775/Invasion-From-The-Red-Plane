using BepInEx;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AwesomeGuy775.RedInvasion{
    public class Hooks{
        public static float OnHeal(On.RoR2.HealthComponent.orig_Heal orig, HealthComponent self, float amount, ProcChainMask procChainMask, bool nonRegen){
            float healedAmount = orig(self, amount, procChainMask, nonRegen);
            if (self.body && self.body != null && self.body.inventory != null && self.body.inventory.GetItemCount(Items.Items.bloodExplosionOnHeal.itemIndex) > 0){
                float maxHealth = self.body.maxHealth;
                Items.BloodExplosionOnHeal.countHeal(healedAmount, maxHealth, self.body);
            }
            return healedAmount;
        }
    }
}