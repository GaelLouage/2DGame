using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private bool platformHit;
    private Transform platform;
    private void Update()
    {
        if (platformHit)
        {
             transform.position = new Vector2(platform.position.x, transform.position.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            platformHit = true;
            platform = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            platformHit = false;
            platform = null;
        }
    }
}
