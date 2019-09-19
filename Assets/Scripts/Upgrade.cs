using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade
{
    public string upgradeName;
    public string description;
    public int cost;
    public int bonusMoves;

    public Upgrade(string upgradeName, string description, int cost, int bonusMoves)
    {
        this.upgradeName = upgradeName;
        this.description = description;
        this.cost = cost;
        this.bonusMoves = bonusMoves;
    }

}
