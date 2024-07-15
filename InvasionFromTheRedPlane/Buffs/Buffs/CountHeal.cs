using BepInEx;
using AwesomeGuy775.RedInvasion;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AwesomeGuy775.RedInvasion.Buffs{
    public sealed class CountHeal{
        public static void init(){
            //language Tokens do this later using this https://risk-of-thunder.github.io/R2Wiki/Mod-Creation/Assets/Localization/
            Buffs.countHeal.name = "COUNTHEAL_NAME";

            //set buff models CHANGE THESE TO ACTUAL MODELS WHEN WE HAVE THEM
            Buffs.countHeal.iconSprite = Addressables.LoadAssetAsync<Sprite>("RoR2/Base/Common/MiscIcons/texMysteryIcon.png").WaitForCompletion();
            Buffs.countHeal.buffColor = Color.green;

            //buff properties
            Buffs.countHeal.canStack = true;

            //add buff to R2API
            ContentAddition.AddBuffDef(Buffs.countHeal);
        }
    }
}