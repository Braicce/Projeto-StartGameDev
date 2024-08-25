using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;

     private PlayerItens playerItens;
        private void Awake()
    {
        playerItens = FindObjectOfType<PlayerItens>();
    }

    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
    }

    void Update()
    {
        waterUIBar.fillAmount = playerItens.currentWater / playerItens.waterLimit;
        woodUIBar.fillAmount = playerItens.totalWood / playerItens.woodLimit;
        carrotUIBar.fillAmount = playerItens.totalCarrots / playerItens.carrotLimit;
    }
}
