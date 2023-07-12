using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PanelBase : MonoBehaviour
{
    [SerializeField]
    protected Transform panelText;
    protected bool panelIsCollision;
    private bool eKeyPressed;
    private void Update()
    {
        if (panelIsCollision && Input.GetKey(KeyCode.E)) 
        {
            eKeyPressed = true;
            
        } 
        if(eKeyPressed && panelIsCollision)
        {
            panelText.gameObject.SetActive(true);
            DoLogic();
        }
        else
        {
            panelText.gameObject.SetActive(false);
            
        }
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
               panelIsCollision = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            panelIsCollision = false;
            eKeyPressed = false;
        }
    }

    protected abstract void DoLogic();
}
