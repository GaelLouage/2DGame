using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    internal static class EnemyPositionExtensions
    {
        internal static void NegativeVectorUpdateUYandXOnReset(this Transform transform)
        {
            transform.position =  new Vector2(transform.position.x - (Time.deltaTime + 0.002f), transform.position.y + Time.deltaTime);
        }

        internal static void PositiveVectorUpdateUYandXOnReset(this Transform transform)
        {
            transform.position = new Vector2(transform.position.x + (Time.deltaTime + 0.002f), transform.position.y + Time.deltaTime);
        }

        internal static void UpdateXYAxis(this Transform transform, char negPos = '+')
        {
            switch (negPos)
            {
                case '-':
                    transform.position = new Vector2(transform.position.x - (Time.deltaTime + 0.002f), transform.position.y - Time.deltaTime);
                    break;
                default:
                    transform.position = new Vector2(transform.position.x + (Time.deltaTime + 0.002f), transform.position.y - Time.deltaTime);
                    break;

            }
        }
        internal static void UpdateXAxis(this Transform transform, char negPos = '+')
        {
            switch (negPos)
            {
                case '-':
                    transform.position = new Vector2(transform.position.x - Time.deltaTime, transform.position.y);
                    break;
                default:
                    transform.position = new Vector2(transform.position.x + Time.deltaTime, transform.position.y);
                    break;

            }
        }
    }
}
