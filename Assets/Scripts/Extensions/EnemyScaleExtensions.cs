using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class EnemyScaleExtensions
    {
        public static void TransformYScale(this Transform transform, float XCurrentScale, float YCurrentScale, char negPos = '+')
        {
            switch(negPos)
            {
                case '-':
                    transform.localScale = new Vector2(XCurrentScale * -1, YCurrentScale);
                    break;
                default:
                    transform.localScale = new Vector2(XCurrentScale, YCurrentScale);
                    break;
            }
        }
        public static void SetAnimation(this Transform transform, AnimatorController animController)
        {
            transform.GetComponent<Animator>().runtimeAnimatorController = animController;
        }
    }
}
