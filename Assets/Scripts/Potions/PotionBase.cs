using Assets.Scripts.Singleton;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using UnityEngine;

public abstract class PotionBase : MonoBehaviour
{
    //[SerializeField]
    //private TextMeshPro potionAmount;
    protected bool playerCollidedWithPotion;
    protected void Update()
    {
        if(playerCollidedWithPotion)
        {
            transform.gameObject.SetActive(false);
            playerCollidedWithPotion = false;
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
