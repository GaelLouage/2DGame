using Assets.Scripts.Enums;
using Assets.Scripts.Extensions;
using Assets.Scripts.Models;
using Assets.Scripts.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PotionUse : MonoBehaviour
{
    private bool speedPotionUsed;
    private bool jumpPotionUsed;
    private float jumpTimer;
    private float speedTimer;

    private void Update()
    {
        // speedPotion used
        PlayerSingleton.Instance.PlayerData.SpeedPotionUsed(ref speedPotionUsed, ref speedTimer);

        // jumpPotion used
        PlayerSingleton.Instance.PlayerData.JumpPotionUsed(ref jumpPotionUsed,ref jumpTimer);

        // keypressed
        if (Input.GetKey(KeyCode.S))
        {
            PlayerSingleton.Instance.PlayerData.UseSpeed(ref speedPotionUsed);
        }
        else if (Input.GetKey(KeyCode.H))
        {
            PlayerSingleton.Instance.PlayerData.UseHealth();
        }
        else if (Input.GetKey(KeyCode.J))
        {
            PlayerSingleton.Instance.PlayerData.UseJump(ref jumpPotionUsed);
        }
    }
}
