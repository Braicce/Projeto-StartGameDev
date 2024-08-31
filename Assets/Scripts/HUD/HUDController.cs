using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Itens")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image fishesUIBar;

    [Header("Tools")]
    //[SerializeField] private Image axeUI;
    //[SerializeField] private Image shovelUI;
    //[SerializeField] private Image bucketUI;

    public List<Image> toolsUI = new List<Image>(); //lista da HUD de Tools

    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;

    private PlayerItens playerItens;
    private Player player;

    private void Awake()
    {
        playerItens = FindObjectOfType<PlayerItens>();
        player = playerItens.GetComponent<Player>(); //instanciando o mesmo objto aproveitando a classe Player
    }

    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        fishesUIBar.fillAmount = 0f;
    }

    void Update()
    {
        waterUIBar.fillAmount = playerItens.currentWater / playerItens.waterLimit;
        woodUIBar.fillAmount = playerItens.totalWood / playerItens.woodLimit;
        carrotUIBar.fillAmount = playerItens.totalCarrots / playerItens.carrotLimit;
        fishesUIBar.fillAmount = playerItens.fishes / playerItens.fishLimit;

        for (int i = 0; i < toolsUI.Count; i++)
        {
            if(i == player.handlingObj)
            {
                toolsUI[i].color = selectColor;
            } 
            else 
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
