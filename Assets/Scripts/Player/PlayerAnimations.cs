using Assets.Scripts.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerAnimations : MonoBehaviour
    {
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }
        private void Update()
        {
            // run animator 
            anim.SetBool("run", PlayerSingleton.Instance.PlayerData.HorizontalMovement != 0);
            // jumpint animator
            anim.SetBool("grounded", PlayerSingleton.Instance.PlayerData.PlayerIsGrounded);
            // hit animation
            anim.SetBool("isHit", PlayerSingleton.Instance.PlayerData.IsHit);
            // crouch animation
            anim.SetBool("isCrouch", PlayerSingleton.Instance.PlayerData.IsCroushed);
        }
    }
}
