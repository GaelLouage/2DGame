using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEnter : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private bool isHouseEntered;
    private int randomChance;
    private void Awake()
    {
       var  random = new System.Random();
       randomChance = random.Next(0, 10);
    }
    private void Update()
    {
        if(isHouseEntered && Input.GetKey(KeyCode.UpArrow)) 
        {
            if(randomChance == 5)
            {
                // top position
                player.position = new Vector2(0.6f, 44f);
            } else
            {
                // start position
                player.position = new Vector2(-16.01f, -5.97f);
            }
           
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isHouseEntered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isHouseEntered = false;
        }
    }

}
