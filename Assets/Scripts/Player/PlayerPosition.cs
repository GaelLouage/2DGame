using Assets.Scripts.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private void Update()
    {
        if(PlayerSingleton.Instance.PlayerData.Health <= 0)
        {
            // if player is dead set the player position to start of the level
            transform.position = new Vector2(-15.69f, -5.9f);
            // reset the playerHealth to 3
            PlayerSingleton.Instance.PlayerData.Health = 3;
        }
    }
}
