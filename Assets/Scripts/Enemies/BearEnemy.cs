using Assets.Scripts.Models;
using Assets.Scripts.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Animations;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Enemies
{
    public class BearEnemy : EnemyBase, IEnemyEntity
    {
        private Vector3 startPosition;
        [SerializeField]
        private float movingDistance;
        [SerializeField]
        private float movingSpeed;
        [SerializeField]
        private int health;

        [SerializeField]
        private AnimatorController deadAnimator;
        private bool movingRight;
        private float bearDeadtimer;
        private bool bearIsDead;
        public int Health
        {
            get => health;
            set
            {
                if (value <= 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        public AnimatorController DeadAnimator { get => deadAnimator; set => deadAnimator = value; }

        protected override void Awake()
        {
            startPosition = transform.position;
        }
        protected override void Update()
        {
            if (PlayerTopHit)
            {
                Health--;
                PlayerHit = false;
                PlayerTopHit = false;
            }
            if (Health <= 0)
            {
                bearIsDead = true;
                transform.GetComponent<Animator>().runtimeAnimatorController = deadAnimator;
                bearDeadtimer += Time.deltaTime;
                if (bearDeadtimer >= 1f)
                {
                    transform.gameObject.SetActive(false);
                    bearDeadtimer = 0f;
                    PlayerTopHit = false;
                }
            }
            if (PlayerHit)
            {
                PlayerSingleton.Instance.PlayerData.Health--;
                PlayerHit = false;
            }
            //if (movingRight && PlayerHit)
            //{
            //    PlayerSingleton.Instance.PlayerData.Health--;
            //    PlayerSingleton.Instance.PlayerData.RigidBody.transform.Translate(Vector2.right * (Time.deltaTime  + 0.02f)* movingSpeed);
            //    PlayerHit = false;
            //}
            //else if (PlayerHit)
            //{
            //    PlayerSingleton.Instance.PlayerData.Health--;
            //    PlayerSingleton.Instance.PlayerData.RigidBody.transform.Translate(Vector2.left * (Time.deltaTime + 0.02f) * movingSpeed);
                
            //    PlayerHit = false;
            //}

            if (!movingRight && !bearIsDead)
            {
                if (transform.position.x > startPosition.x - movingDistance)
                {
                    transform.localScale = new Vector3(-2.7859f, 3.0312f, 0);
                    //This applies the movement relative to the object's current position.
                    transform.Translate(Vector2.left * Time.deltaTime * movingSpeed);
                }
                if (transform.position.x <= startPosition.x - movingDistance)
                {
                    movingRight = true;
                }
            }
            else if(!bearIsDead)
            {
                if (transform.position.x < startPosition.x + movingDistance)
                {
                    transform.localScale = new Vector3(2.7859f, 3.0312f, 0);
                    transform.Translate(Vector2.right * Time.deltaTime * movingSpeed);
                }
                if (transform.position.x >= startPosition.x + movingDistance)
                {
                    movingRight = false;
                }
            }

        }
    }
}
