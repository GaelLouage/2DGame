using Assets.Scripts.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public static class EnemyHelpers 
{
    public static void UpdateLeftPosition(Transform transform, Transform player)
    {
        if (transform.position.y > player.position.y + 0.02f)
        {
            transform.UpdateXYAxis('-');
        }
        else if (transform.position.x > player.position.x)
        {
            transform.UpdateXAxis('-');
        }
    }

    public static void UpdateRightPosition(Transform transform, Transform player)
    {
        if (transform.position.y > player.position.y + 0.0f)
        {
            transform.UpdateXYAxis();
        }
        else if (transform.position.x < player.position.x)
        {
            transform.UpdateXAxis();
        }
    }

    public static void ResteBatPosition(Transform transform, Vector2 startPosition, float xCurrentScale, float yCurrentScale, AnimatorController animController)
    {
        // down bat position
        if (transform.position.y < startPosition.y)
        {

            if (transform.position.x < startPosition.x)
            {
                transform.TransformYScale(xCurrentScale, yCurrentScale);
                transform.PositiveVectorUpdateUYandXOnReset();
            }
            else
            {
                transform.TransformYScale(xCurrentScale, yCurrentScale, '-');
                transform.NegativeVectorUpdateUYandXOnReset();
            }
        }
        else
        {
            transform.SetAnimation(animController);
        }
    }
   
}
