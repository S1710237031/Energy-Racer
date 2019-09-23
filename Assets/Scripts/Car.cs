using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car
{
    public string carName;
    public string description;
    public int cost;
    public int movesReduction;
    public Image img;
    public string owned;

    public Car(string carName, string description, int cost, int movesReduction)
    {
        this.carName = carName;
        this.description = description;
        this.cost = cost;
        this.movesReduction = movesReduction;
        this.owned = "not owned";
    }
}
