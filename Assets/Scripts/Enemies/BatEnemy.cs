using Assets.Scripts.Extensions;
using Assets.Scripts.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class BatEnemy : EnemyBase
    {
        [SerializeField]
        protected AnimatorController AnimControllerIdle;
        [SerializeField]
        protected AnimatorController AnimControllerAttack;
        protected override void Awake()
        {
            XCurrentScale = transform.localScale.x;
            YCurrentScale = transform.localScale.y;
            StartPosition = transform.position;
        }
        protected override void Update()
        {
            if (Player.transform.position.x > transform.position.x && Player.transform.position.x < transform.position.x + 5)
            {
                transform.TransformYScale(XCurrentScale, YCurrentScale);
                transform.SetAnimation(AnimControllerAttack);
                EnemyHelpers.UpdateRightPosition(transform,Player);
            }
            else if (Player.transform.position.x < transform.position.x && Player.transform.position.x > transform.position.x - 5)
            {
                transform.SetAnimation(AnimControllerAttack);
                transform.TransformYScale(XCurrentScale, YCurrentScale, '-');
                EnemyHelpers.UpdateLeftPosition(transform, Player);
            }
            else
            {
                EnemyHelpers.ResteBatPosition(transform,StartPosition, XCurrentScale, YCurrentScale, AnimControllerIdle);
            }
        }
    }
}

