using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonthObject 
{
    public string Name { get; set; }
    public double BestCase { get; set; }
    public double AverageCase { get; set; }
    public double WorstCase { get; set; }
    public double SunFactor { get; set; }

    public MonthObject(string _name, double _best, double _average, double _worst, double _avgSunHours)
    {
        Name = _name;
        BestCase = _best;
        AverageCase = _average;
        WorstCase = _worst;
        SunFactor = _avgSunHours / 0.24;
    }
}
