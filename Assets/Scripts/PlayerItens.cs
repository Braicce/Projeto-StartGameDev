using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [Header("Amounts")]
    public int totalWood;
    public int totalCarrots;
    public float currentWater;
    public int fishes;

    [Header("Limits")]
    public float waterLimit = 50;
    public float woodLimit = 5;
    public float carrotLimit = 10;
    public float fishLimit = 5;

    public void WaterLimit(float water)
    {
        if(currentWater < 50)
        {
            currentWater += water;
        }
    }

}
