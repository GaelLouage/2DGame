using Assets.Scripts.Models;
using Assets.Scripts.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    internal static class PlayerExtensions
    {
        public static void FlipPlayer(this PlayerSingleton player, Transform transform)
        {
            if (player.PlayerData.HorizontalMovement > 0.01f)
            {
                transform.localScale = new Vector3(4f, 4, 1);
                player.PlayerData.IsCroushed = false;
            }
            if (player.PlayerData.HorizontalMovement < -0.01f)
            {
                transform.localScale = new Vector3(-4f, 4, 1);
                player.PlayerData.IsCroushed = false;
            }
        }
        public static void Crouch(this PlayerSingleton player, Transform transform)
        {
            if(player.PlayerData.VerticalMovement < 0 && player.PlayerData.PlayerIsGrounded)
            {
                player.PlayerData.IsCroushed = true;
            } else
            {
                player.PlayerData.IsCroushed = false;
            }
        }
        public static void Jump(this PlayerSingleton player, Transform transform)
        {
            if (Input.GetKeyDown(KeyCode.Space) && player.PlayerData.PlayerIsGrounded)
            {
                player.PlayerData.RigidBody.velocity = new Vector2(player.PlayerData.RigidBody.velocity.x, player.PlayerData.JumpForce);
                player.PlayerData.PlayerIsGrounded = false;
                player.PlayerData.IsCroushed = false;
            }
        }
    }
}
