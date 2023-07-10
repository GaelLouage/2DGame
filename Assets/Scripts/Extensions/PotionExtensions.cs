using Assets.Scripts.Enums;
using Assets.Scripts.Models;
using Assets.Scripts.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Assets.Scripts.Extensions
{
    public static class PotionExtensions
    {
        public static Action AddPotion(this PlayerEntity playerData, TypeOfPotion potionType)
        {
            var potionDictionary = new Dictionary<TypeOfPotion, Action>()
           {
            {TypeOfPotion.Health, () => playerData.HealtPotion++ },
            {TypeOfPotion.Speed ,() => playerData.SpeedPotion++ },
            {TypeOfPotion.Jump, () => playerData.JumpPotion++ }
           };
            return potionDictionary[potionType];
        }
        public static Action UsePotion(this PlayerEntity playerData, TypeOfPotion potionType)
        {
            var potionDictionary = new Dictionary<TypeOfPotion, Action>()
           {
            {TypeOfPotion.Health, () => playerData.HealtPotion-- },
            {TypeOfPotion.Speed ,() => playerData.SpeedPotion-- },
            {TypeOfPotion.Jump, () => playerData.JumpPotion-- }
           };
            return potionDictionary[potionType];
        }

        public static void JumpPotionUsed(this PlayerEntity player,ref bool jumpPotionUsed,ref float jumpTimer)
        {
            if (jumpPotionUsed)
            {
                player.JumpForce = 25;
                jumpTimer += Time.deltaTime;
                Debug.Log("jumpTimer: " + jumpTimer);
                if (jumpTimer >= 2)
                {
                    jumpPotionUsed = false;
                    jumpTimer = 0;
                    player.JumpForce = 7;
                }
            }
        }
        public static void SpeedPotionUsed(this PlayerEntity player,ref bool speedPotionUsed, ref float speedTimer)
        {
            if (speedPotionUsed)
            {
                player.Speed = 25;
                speedTimer += Time.deltaTime;
                Debug.Log("speedtimer: " + speedTimer);
                if (speedTimer >= 2)
                {
                    speedPotionUsed = false;
                    speedTimer = 0;
                    player.Speed = 5;
                }
            }
        }
        public static void UseHealth(this PlayerEntity player)
        {
            if (player.HealtPotion > 0 && player.Health < 3)
            {
                player.UsePotion(TypeOfPotion.Health)?.Invoke();
                player.AddHealth();
            }
        }
        public static void UseSpeed(this PlayerEntity player,  ref bool speedPotionUsed)
        {
            if (player.SpeedPotion > 0)
            {
                player.UsePotion(TypeOfPotion.Speed)?.Invoke();
                speedPotionUsed = true;
            }
        }
        public static void UseJump(this PlayerEntity player, ref bool jumpPotionUsed)
        {
            if (player.JumpPotion > 0)
            {
                player.UsePotion(TypeOfPotion.Jump)?.Invoke();
                jumpPotionUsed = true;
            }
        }
    }
}
