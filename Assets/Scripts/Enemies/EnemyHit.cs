using Assets.Scripts.Enemies;
using Assets.Scripts.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : EnemyBase
{
    [SerializeField]
    protected int EnemyDamage;

 

    protected override void Awake()
    {
        
    }

    protected override void Update()
    {
        if (PlayerHit)
        {
            if (!EnemyFirstHit)
            {
                PlayerSingleton.Instance.PlayerData.Health -= EnemyDamage;
                EnemyFirstHit = true;
            }
            else
            {
                EnemyAttackTimer += Time.deltaTime;
                if (EnemyAttackTimer > 1)
                {
                    PlayerSingleton.Instance.PlayerData.Health -= EnemyDamage;
                    EnemyAttackTimer = 0;
                }
            }
        }
    }

}
