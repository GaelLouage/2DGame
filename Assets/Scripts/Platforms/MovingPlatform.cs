using Assets.Scripts.Enums;
using Assets.Scripts.Extensions;
using Assets.Scripts.Singleton;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float movementDistance;
    [SerializeField]
    private float speed;
    private bool movingLeft;
    private float leftEdge;
    private bool playerCollision;
    private float rightEdge;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private bool reverse;


  

    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }
    private void Update()
    {
        if (reverse)
        {
            PlatformDirection.ReverseDirection(ref movingLeft, transform, speed, ref player, rightEdge, leftEdge, playerCollision);
        }
        else
        {
            PlatformDirection.NonReverseDirection(ref movingLeft, transform, speed, ref player, rightEdge, leftEdge, playerCollision);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        
        if (collision.collider.CompareTag("Player"))
        {
            playerCollision = true;
            // ad logic if playerspeed is not as fast as platform or faster thane platform
            PlayerSingleton.Instance.PlayerData.PlayerIsGrounded = true;
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // reset the player speed to original speed
            playerCollision = false;
            PlayerSingleton.Instance.PlayerData.Speed = 5;
        }
    }
}
