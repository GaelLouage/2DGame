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
    public abstract class EnemyBase : MonoBehaviour
    {
      
        [SerializeField]
        protected Transform Player;

        protected float XCurrentScale;
        protected float YCurrentScale;

        protected Vector2 StartPosition;
        protected bool PlayerHit;
        protected bool EnemyFirstHit;
        protected float EnemyAttackTimer;
        protected abstract void Awake();
        protected abstract void Update();

        protected bool PlayerTopHit;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                // Check if the collision point is above the bear's position
                foreach (ContactPoint2D contact in collision.contacts)
                {
                    if (contact.point.y > transform.position.y)
                    {
                        PlayerTopHit = true;
                        break;
                    } else
                    {
                        PlayerHit = true;
                        break;
                    }
                }
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                PlayerHit = false;
                EnemyFirstHit = false;
                PlayerTopHit = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                PlayerHit = true;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                PlayerHit = false;
                EnemyFirstHit = false;
            }
        }
    }
}
