using Assets.Scripts.Enums;
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

        private int speedPotion;
        private int healtPotion;        private int jumpPotion;
        private int health;
        public PlayerEntity( int health = 3, float speed = 5, float jumpForce = 5)
        {
            Health = health;
            Speed = speed;
            JumpForce = jumpForce;
        }

        public Rigidbody2D RigidBody { get; set; }
        public int Health 
        { 
            get => health;
            set 
            {
                if(value <= 0)
                {
                    health = 0;
                } else if(value > 3) 
                {
                    health = 3;
                } else
                {
                    health = value;
                }
            } 
        }
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
        public int SpeedPotion 
        {
            get => speedPotion;
            set 
            {
                if (value <= 0)
                {
                    speedPotion = 0;
                }
                else
                {
                    speedPotion = value;
                }
            } 
        }
        public int HealtPotion 
        {
            get => healtPotion;
            set 
            {
                if (value <= 0)
                {
                    healtPotion = 0;
                }
                else
                {
                    healtPotion = value;
                }
            }
        }
        public int JumpPotion 
        {
            get => jumpPotion;
            set
            {
                if (value <= 0)
                {
                    jumpPotion = 0;
                }
                else
                {
                    jumpPotion = value;
                }
            }
        }

        public void AddHealth()
        {
            health++;
        }
    }
}
