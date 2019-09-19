using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMonths
{
    public static MonthObject[] Months = new MonthObject[12];

    private void SetAllMonths()
    {
        MonthObject jan = new MonthObject("January", 100, 50, 1);
        MonthObject feb = new MonthObject("February", 100, 50, 1);
        MonthObject mar = new MonthObject("March", 100, 50, 1);
        MonthObject apr = new MonthObject("Arpil", 100, 50, 1);
        MonthObject may = new MonthObject("May", 100, 50, 1);
        MonthObject jun = new MonthObject("June", 100, 50, 1);
        MonthObject jul = new MonthObject("July", 100, 50, 1);
        MonthObject aug = new MonthObject("August", 100, 50, 1);
        MonthObject sep = new MonthObject("September", 100, 50, 1);
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
