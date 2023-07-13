using Assets.Scripts.Extensions;
using Assets.Scripts.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Animations;
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
            anim.SetBool("isRunning", PlayerSingleton.Instance.PlayerData.HorizontalMovement != 0);
            anim.SetBool("isGrounded", PlayerSingleton.Instance.PlayerData.PlayerIsGrounded);
        }
    }
}
