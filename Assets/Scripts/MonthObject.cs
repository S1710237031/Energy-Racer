using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonthObject 
{
    private string Name { get; set; }
    private double BestCase { get; set; }
    private double AverageCase { get; set; }
    private double WorstCase { get; set; }

    public MonthObject(string _name, double _best, double _average, double _worst)
    {
        Name = _name;
        BestCase = _best;
        AverageCase = _average;
        WorstCase = _worst;
    }
}
