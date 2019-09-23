using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMonths
{
    public static MonthObject[] Months = new MonthObject[12];

    private void SetAllMonths()
    {
        MonthObject jan = new MonthObject("January", 100, 90, 1);
        MonthObject feb = new MonthObject("February", 185, 133.17, 6.7);
        MonthObject mar = new MonthObject("March", 202, 99.55, 15.4);
        MonthObject apr = new MonthObject("Arpil", 218, 145.33, 33.5);
        MonthObject may = new MonthObject("May", 181, 103.68, 20);
        MonthObject jun = new MonthObject("June", 216, 169, 63);
        MonthObject jul = new MonthObject("July", 216, 142.42, 22);
        MonthObject aug = new MonthObject("August", 206, 136.26, 48.6);
        MonthObject sep = new MonthObject("September", 201, 50, 15);
        MonthObject oct = new MonthObject("October", 100, 50, 1);
        MonthObject nov = new MonthObject("November", 100, 50, 1);
        MonthObject dec = new MonthObject("December", 100, 50, 1);

        SetArray(0, jan);
        SetArray(1, feb);
        SetArray(2, mar);
        SetArray(3, apr);
        SetArray(4, may);
        SetArray(5, jun);
        SetArray(6, jul);
        SetArray(7, aug);
        SetArray(8, sep);
        SetArray(9, oct);
        SetArray(10, nov);
        SetArray(11, dec);
    }

    private void SetArray(int _index, MonthObject _month)
    {
        Months[_index] = _month;
    }
}
