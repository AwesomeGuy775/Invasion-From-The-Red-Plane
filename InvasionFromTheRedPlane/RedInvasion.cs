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
    [BepInDependency(ItemDropAPI.PluginGUID)]
    [BepInDependency(LanguageAPI.PluginGUID)]
    public class RedInvasion : BaseUnityPlugin
    {
        private static ItemDef bloodExplosionOnHeal;
        private void Awake()
        {
            //plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            //define crimson relic
            bloodExplosionOnHeal = ScriptableObject.CreateInstance<ItemDef>();
            //language Tokens
            //do this later using this https://risk-of-thunder.github.io/R2Wiki/Mod-Creation/Assets/Localization/
            //lang tokens go here
            //set item tier
#pragma warning disable Publicizer001
            bloodExplosionOnHeal._itemTierDef = Addressables.LoadAssetAsync<ItemTierDef>("RoR2/Base/Common/Tier2Def.asset").WaitForCompletion();
#pragma warning restore Publicizer001
            //set item models CHANGE THESE TO ACTUAL MODELS WHEN WE HAVE THEM
            bloodExplosionOnHeal.pickupIconSprite = Addressables.LoadAssetAsync<Sprite>("RoR2/Base/Common/MiscIcons/texMysteryIcon.png").WaitForCompletion();
            bloodExplosionOnHeal.pickupModelPrefab = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Mystery/PickupMystery.prefab").WaitForCompletion();
            //set non-gameplay item properties
            bloodExplosionOnHeal.canRemove = true; //can be taken my printer, shrine of order, etc
            bloodExplosionOnHeal.hidden = false; //there will be a pickup notification
            //add item desplay rules later. for now these are null
            var bloodExplosionOnHealDisplayRules = new ItemDisplayRuleDict(null);
            //add item to R2API
            var bloodExplosionOnHealIndex = ItemAPI.Add(new CustomItem(bloodExplosionOnHeal, bloodExplosionOnHealDisplayRules));
        }
    }
}
