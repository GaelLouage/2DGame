using Assets.Scripts.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    private UnityEngine.UI.Image totalHealthBar;
    [SerializeField]
    private UnityEngine.UI.Image currentHealthBar;
    private void Start()
    {
        totalHealthBar.fillAmount = PlayerSingleton.Instance.PlayerData.Health * 0.1f;
    }
    private void Update()
    {
        currentHealthBar.fillAmount = PlayerSingleton.Instance.PlayerData.Health * 0.1f;
    }
}
