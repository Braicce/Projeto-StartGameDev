﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    public int totalWood;

    public float currentWater;
    private float waterLimit = 50;

    public void WaterLimit(float water)
    {
        if(currentWater < 50)
        {
            currentWater += water;
        }
    }

}
