using BepInEx;
using AwesomeGuy775.RedInvasion;
using R2API;
using RoR2;
using RoR2.Items;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Linq;


namespace AwesomeGuy775.RedInvasion.Buffs{
    public static class Buffs{
        public static BuffDef countHeal = ScriptableObject.CreateInstance<BuffDef>();

        public static void addStacks(CharacterBody body, int amount, BuffDef buff){
            body.SetBuffCount(buff.buffIndex, body.GetBuffCount(buff.buffIndex)+amount);
        }

        public static void removeStacks(CharacterBody body, int amount, BuffDef buff){
            body.SetBuffCount(buff.buffIndex, Mathf.Max(0, body.GetBuffCount(buff.buffIndex)-amount));
        }

        public static void addStacksTimed(CharacterBody body, int amount, BuffDef buff, float duration){
            for (int i = 0; i < amount; i++){
                body.AddTimedBuff(buff, duration);
            }
        }

        public static void removeStacksTimed(CharacterBody body, int stacks, BuffDef buff){
            if (body.HasBuff(buff.buffIndex)){
                var buffTimers = body.timedBuffs
                .Where(timedBuff => timedBuff.buffIndex == buff.buffIndex)
                .OrderBy(timedBuff => timedBuff.timer)
                .ToList();
                for (int i = 0; i < stacks && i < buffTimers.Count; i++)
                {
                    buffTimers[i].timer = 0;
                }
                body.timedBuffs.RemoveAll(timedBuff => timedBuff.timer <= 0);
            } 
        }
    }
}