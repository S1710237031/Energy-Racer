using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMonths
{
    public static MonthObject[] Months = new MonthObject[12];

    private void SetAllMonths()
    {
        MonthObject jan = new MonthObject("Jänner", 100, 90, 10, 2);
        MonthObject feb = new MonthObject("Februar", 185, 133.17, 6.7, 3.5);
        MonthObject mar = new MonthObject("März", 202, 99.55, 15.4, 4.8);
        MonthObject apr = new MonthObject("Arpil", 218, 145.33, 33.5, 6.8);
        MonthObject may = new MonthObject("Mai", 181, 103.68, 20, 6.9);
        MonthObject jun = new MonthObject("Juni", 216, 169, 63, 7.5);
        MonthObject jul = new MonthObject("Juli", 216, 142.42, 22, 7.8);
        MonthObject aug = new MonthObject("August", 206, 136.26, 48.6, 7.5);
        MonthObject sep = new MonthObject("September", 201, 50, 15, 5.9);
        MonthObject oct = new MonthObject("Oktober", 100, 50, 1, 4.1);
        MonthObject nov = new MonthObject("November", 100, 50, 1, 2.2);
        MonthObject dec = new MonthObject("Dezember", 100, 50, 1, 1.9);

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

    // ?? not used yet
    private void CalulateSunHours()
    {

    }
}
