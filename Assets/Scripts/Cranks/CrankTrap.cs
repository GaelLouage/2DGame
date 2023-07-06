using Assets.Scripts.Cranks;
using Assets.Scripts.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankTrap : BaseCrank
{
    [SerializeField]
    private Transform spike;

    private float timer;
    
    private bool keyCodeEPressed;
    private float spikeStartPositionY;
    private void Awake()
    {
        spikeStartPositionY = spike.transform.position.y;
    }
    protected override void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            keyCodeEPressed = true;
        }
        if(crankToggle && keyCodeEPressed)
        {
            timer += Time.deltaTime;
            if (timer < 2)
            {
                spike.transform.position = new Vector2(spike.transform.position.x, spikeStartPositionY + 0.7f);
                transform.GetComponent<SpriteRenderer>().sprite = crankDown;

            } else 
            {
                spike.transform.position = new Vector2(spike.transform.position.x, spikeStartPositionY);
                transform.GetComponent<SpriteRenderer>().sprite = crankUp;
                crankToggle = false;
                keyCodeEPressed = false;
                timer = 0;
            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            crankToggle = true;
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            crankToggle = false;
        }
    }
}
