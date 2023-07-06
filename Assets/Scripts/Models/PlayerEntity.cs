using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class PlayerEntity
    {
        public PlayerEntity( int health, float speed, float jumpForce)
        {
            Health = health;
            Speed = speed;
            JumpForce = jumpForce;
        }

        public Rigidbody2D RigidBody { get; set; }
        public int Health { get; set; }
        // movements
        public float Speed { get; set; }
        public float JumpForce { get; set; }
        public float HorizontalMovement { get; set; }
        public float VerticalMovement { get; set; }
        //collisoins
        public bool PlayerIsGrounded { get;set; }
        public bool IsHit { get; set; }
        public bool IsCroushed { get; set; }
        // platform collision
        public bool IsOnPlatform { get; set; }

        // potions
        public int  SpeedPotion { get; set; }
        public int  HealtPotion {get;set; }        public int JumpPotion { get; set; }    

    }
}
