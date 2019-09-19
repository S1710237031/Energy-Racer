using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car
{
    public string upgradeName;
    public string description;
    public int cost;
    public int movesReduction;
    public Image img;

    public Car(string upgradeName, string description, int cost, int movesReduction)
    {
        this.upgradeName = upgradeName;
        this.description = description;
        this.cost = cost;
        this.movesReduction = movesReduction;
    }
}
