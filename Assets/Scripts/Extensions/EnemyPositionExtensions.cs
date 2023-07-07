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
            float delta = Time.deltaTime + 0.002f;
            float x = transform.position.x + (negPos == '-' ? -delta : delta);
            float y = transform.position.y - Time.deltaTime;
            transform.position = new Vector2(x, y);
        }
        internal static void UpdateXAxis(this Transform transform, char negPos = '+')
        {
            float delta = Time.deltaTime + 0.002f;
            float x = transform.position.x + (negPos == '-' ? -delta : delta);
            transform.position = new Vector2(x, transform.position.y);
        }
    }
}
