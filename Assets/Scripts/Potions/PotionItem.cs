using Assets.Scripts.Enums;
using Assets.Scripts.Extensions;
using Assets.Scripts.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using UnityEditor.Build.Player;
using UnityEngine;

public  class PotionItem : MonoBehaviour
{
    [SerializeField]
    private TypeOfPotion potionType;
    //[SerializeField]
    //private TextMeshPro potionAmount;
    private bool playerCollidedWithPotion;
    private void Update()
    {
        if(playerCollidedWithPotion)
        {
            transform.gameObject.SetActive(false);
            playerCollidedWithPotion = false;
            // ensure that action is invoke when not null ( ?.Invoke();)
            PlayerSingleton.Instance.PlayerData.AddPotion(potionType)?.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCollidedWithPotion = true;
        }
    }
}
