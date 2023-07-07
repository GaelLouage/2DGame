using Assets.Scripts.Enums;
using Assets.Scripts.Models;
using Assets.Scripts.Singleton;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class PotionAmount : MonoBehaviour
{
    [SerializeField]
    private  TypeOfPotion potionType;

    private void Update()
    {
        var potionDictionary = new Dictionary<TypeOfPotion, string>()
        {
            {TypeOfPotion.Health,$"x {PlayerSingleton.Instance.PlayerData.HealtPotion}" },
            {TypeOfPotion.Speed,$"x {PlayerSingleton.Instance.PlayerData.SpeedPotion}" },
            {TypeOfPotion.Jump,$"x {PlayerSingleton.Instance.PlayerData.JumpPotion}" }
        };
        transform.gameObject.GetComponent<TextMeshProUGUI>().text = potionDictionary[potionType];
    }
}
