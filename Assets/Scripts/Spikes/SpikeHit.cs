using Assets.Scripts.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHit : MonoBehaviour
{
    private bool playerSpikeHit;
    private float timer;
    private bool firstTimeHit;
    private int hitCounter;
    private void Update()
    {
        if (PlayerSingleton.Instance.PlayerData.IsHit)
        {
            if(hitCounter == 0)
            {
                PlayerSingleton.Instance.PlayerData.Health -= 1;
                timer = 0;
            }
            hitCounter++;
            timer += Time.deltaTime;
            if (timer > 2) 
            {
                PlayerSingleton.Instance.PlayerData.Health -= 1;
                timer = 0;
            }
         
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            playerSpikeHit = true;
            PlayerSingleton.Instance.PlayerData.IsHit = true;
            PlayerSingleton.Instance.PlayerData.PlayerIsGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            firstTimeHit = false;
            PlayerSingleton.Instance.PlayerData.IsHit = false;
            PlayerSingleton.Instance.PlayerData.PlayerIsGrounded = false;
            timer = 0;
            hitCounter = 0;
        }
    }
}
