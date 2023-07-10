using Assets.Scripts.Singleton;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCrate : MonoBehaviour
{
    private bool playerCollideWithCrate;
    private Transform crate;
    private float cratePosition;
    private void Update()
    {
    
        // separate this
        if (playerCollideWithCrate && Input.GetKey(KeyCode.E))
        {
            if (PlayerSingleton.Instance.PlayerData.HorizontalMovement > 0.01f)
            {
                cratePosition = transform.position.x + 1f;
            }
            if (PlayerSingleton.Instance.PlayerData.HorizontalMovement < -0.01f)
            {
                cratePosition = transform.position.x + (-1f);
            }
            crate.position = new Vector2(transform.position.x, transform.position.y);

        }
        if (!Input.GetKey(KeyCode.E))
        {
            playerCollideWithCrate = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("crateBig"))
        {
            PlayerSingleton.Instance.PlayerData.PlayerIsGrounded = true;
            playerCollideWithCrate = true;
            crate = collision.transform;
        }
    }
}
