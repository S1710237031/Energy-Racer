using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// stores upgrades
/// </summary>
public class Upgrade
{
    public string upgradeName;
    public string description;
    public int cost;
    public int bonusMoves;
    public string owned;

    public Upgrade(string upgradeName, string description, int cost, int bonusMoves)
    {
        this.upgradeName = upgradeName;
        this.description = description;
        this.cost = cost;
        this.bonusMoves = bonusMoves;
        this.owned = "not owned";
    }

}
