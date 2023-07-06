using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    internal class PlatformDirection
    {
        internal static void NonReverseDirection(ref bool movingLeft, Transform transform, float speed, ref Transform player, float rightEdge, float leftEdge, bool playerCollision)
        {
            if (movingLeft)
            {
                if (transform.position.x > leftEdge)
                {
                    LeftEdge(transform, speed, player, playerCollision);
                }
                else
                {
                    movingLeft = false;
                }
            }
            else
            {
                if (transform.position.x < rightEdge)
                {
                    RightEdge(transform, speed, player, playerCollision);
                }
                else
                {
                    movingLeft = true;
                }
            }
        }

        private static void RightEdge(Transform transform, float speed, Transform player, bool playerCollision)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (playerCollision)
            {
                player.position = new Vector3(player.position.x + speed * Time.deltaTime, player.position.y, player.position.z);
            }
        }

        private static void LeftEdge(Transform transform, float speed, Transform player, bool playerCollision)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (playerCollision)
            {
                player.position = new Vector3(player.position.x - speed * Time.deltaTime, player.position.y, player.position.z);
            }
        }

        internal static void ReverseDirection(ref bool movingLeft, Transform transform, float speed, ref Transform player, float rightEdge, float leftEdge, bool playerCollision)
        {
            if (movingLeft)
            {
                if (transform.position.x < rightEdge)
                {
                    RightEdge(transform, speed, player, playerCollision);
                }
                else
                {
                    movingLeft = false;
                }
            }
            else
            {
                if (transform.position.x > leftEdge)
                {
                    LeftEdge(transform, speed, player, playerCollision);
                }
                else
                {
                    movingLeft = true;
                }
            }
        }
    }
}
