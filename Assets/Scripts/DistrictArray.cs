using UnityEngine;
using System;

public static class DistrictArray
{
    public static District[] DisrictArr;
    private static int DistrictNumber = 27;
    public static double Max = 681.77;

    public static District[] GetAllDistricts()
    {
        if (DisrictArr == null)
        {
            SetAllDistricts();
        }
        return DisrictArr;
    }

    public static District GetDistrict(int _index)
    {
        if (DisrictArr == null)
        {
            SetAllDistricts();
        }

        if (_index == 0 && Board.isMultiplayer)
        {
            _index = 1;
        }
        if (Board.isMultiplayer)
        {
            return DisrictArr[0];
        }
        return DisrictArr[_index];
    }

    /// <summary>
    /// Einwohnerzahlen von Statistik Austria, Stand: Jänner 2019
    /// Photovoltaik / 1000 Einwohner Statistik Austria (ATLAS), Stand: Oktober 2019
    /// </summary>
    private static void SetAllDistricts()
    {
        DisrictArr = new District[DistrictNumber];
        District badZell = new District("Bad Zell", 48.3496, 14.6686, 2913, 143.76, 45.52);
        District freistadt = new District("Freistadt", 48.5113, 14.5048, 7960, 85.65, 12.86);
        District gruenbach = new District("Gruenbach", 48.5365, 14.5365, 1924, 129.57, 36.08);
        District gutau = new District("Gutau", 48.4184, 14.6122, 2672, 146.69, 45.28);
        District hagenberg = new District("Hagenberg", 48.3674, 14.5169, 2751, 59.92, 15.05);
        District hirschbach = new District("Hirschbach", 48.4883, 14.4113, 1202, 96.66, 23.63);
        District kaltenberg = new District("Kaltenberg", 46.7722, 14.5671, 622, 159.57, 17.20);
        District kefermarkt = new District("Kefermarkt", 48.443, 14.5384, 2138, 89.54, 27.81);
        District koenigswiesen = new District("Koenigswiesen", 48.4057, 14.8388, 3091, 72.27, 73.38);
        District lasberg = new District("Lasberg", 48.4714, 14.5408, 2796, 88.69, 43.80);
        District leopoldschlag = new District("Leopoldschlag", 48.6159, 14.5036, 1015, 79.22, 25.80);
        District liebenau = new District("Liebenau", 48.532, 14.8052, 1585, 57.08, 76.31);
        District neumarkt = new District("Neumarkt", 48.4283, 14.4845, 3163, 81.01, 46.67);
        District pierbach = new District("Pierbach", 48.3482, 14.7565, 1016, 83.19, 22.72);
        District pregarten = new District("Pregarten", 48.355, 14.5308, 5422, 88.92, 27.77);
        District rainbach = new District("Rainbach", 48.5576, 14.4765, 2989, 77.88, 49.27);
        District sandl = new District("Sandl", 48.5604, 14.6444, 1413, 132.45, 58.32);
        District schoenau = new District("Schoenau", 48.3942, 14.7291, 1949, 150.53, 38.54);
        District sanktLeonhard = new District("St. Leonhard", 48.4436, 14.6776, 1388, 129.09, 35.01);
        District sanktOswald = new District("St. Oswald", 48.5006, 14.5877, 2906, 93.52, 40.98);
        District tragwein = new District("Tragwein", 48.332, 14.6212, 3099, 148.41, 39.47);
        District unterweissenbach = new District("Unterweissenbach", 46.9516, 15.8625, 2174, 165.58, 48.73);
        District unterweitersdorf = new District("Unterweitersdorf", 48.3673, 14.4689, 2161, 100.10, 11.42);
        District waldburg = new District("Waldburg", 48.509, 14.439, 1382, 85.50, 26.53);
        District wartberg = new District("Wartberg ob der Aist", 48.3503, 14.5082, 4276, 118.07, 19.41);
        District weitersfelden = new District("Weitersfelden", 48.4779, 14.7265, 1047, 125.99, 43.72);
        District windhaag = new District("Windhaag", 48.5862, 14.5615, 1567, 180.20, 42.83);

        DisrictArr[0] = freistadt;
        DisrictArr[1] = wartberg;
        DisrictArr[2] = pregarten;
        DisrictArr[3] = tragwein;
        DisrictArr[4] = badZell;
        DisrictArr[5] = gutau;
        DisrictArr[6] = unterweissenbach;
        DisrictArr[7] = schoenau;
        DisrictArr[8] = windhaag;
        DisrictArr[9] = sanktOswald;
        DisrictArr[10] = neumarkt;
        DisrictArr[11] = gruenbach;
        DisrictArr[12] = lasberg;
        DisrictArr[13] = rainbach;
        DisrictArr[14] = koenigswiesen;
        DisrictArr[15] = unterweitersdorf;
        DisrictArr[16] = kefermarkt;
        DisrictArr[17] = sandl;
        DisrictArr[18] = sanktLeonhard;
        DisrictArr[19] = hagenberg;
        DisrictArr[20] = weitersfelden;
        DisrictArr[21] = waldburg;
        DisrictArr[22] = hirschbach;
        DisrictArr[23] = kaltenberg;
        DisrictArr[24] = liebenau;
        DisrictArr[25] = pierbach;
        DisrictArr[26] = leopoldschlag;    
    }
}
