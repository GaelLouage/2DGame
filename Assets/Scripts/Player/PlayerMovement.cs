using Assets.Scripts.Enums;
using Assets.Scripts.Extensions;
using Assets.Scripts.Singleton;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMovement : MonoBehaviour
{
  
    private PlayerSingleton player;
    [SerializeField]
    private int health;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;

    private void Awake()
    {
        player = PlayerSingleton.Instance;
        player.PlayerData = new Assets.Scripts.Models.PlayerEntity(health,speed,jumpForce);
        player.PlayerData.RigidBody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        // Horizontal Movement
        player.PlayerData.HorizontalMovement = Input.GetAxis("Horizontal");
        player.PlayerData.RigidBody.velocity = new Vector2(player.PlayerData.HorizontalMovement * player.PlayerData.Speed, player.PlayerData.RigidBody.velocity.y);
        player.PlayerData.VerticalMovement = Input.GetAxis("Vertical");
        // flip the player position if player is going left right
        player.FlipPlayer(transform);
        // jump is space key is pressed;
        player.Jump(transform);
        // croushing
        player.Crouch(transform);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            player.PlayerData.PlayerIsGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            player.PlayerData.PlayerIsGrounded = false;
        }
    }
}
