﻿public static class DistrictArray
{
    public static District[] DisrictArr;
    private static int DistrictNumber = 27;

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
        return DisrictArr[_index];
    }

    /// <summary>
    /// Einwohnerzahlen von Statistik Austria, Stand: Jänner 2019
    /// Photovoltaik / 1000 Einwohner Statistik Austria (ATLAS), Stand: Oktober 2019
    /// </summary>
    private static void SetAllDistricts()
    {
        DisrictArr = new District[DistrictNumber];
        District badZell = new District("Bad Zell", 48.3496, 14.6686, 2913, 20.55);
        District freistadt = new District("Freistadt", 48.5113, 14.5048, 7960, 12.39);
        District gruenbach = new District("Gruenbach", 48.5365, 14.5365, 1924, 13.12);
        District gutau = new District("Gutau", 48.4184, 14.6122, 2672, 22.39);
        District hagenberg = new District("Hagenberg", 48.3674, 14.5169, 2751, 12.06);
        District hirschbach = new District("Hirschbach", 48.4883, 14.4113, 1202, 29.77);
        District kaltenberg = new District("Kaltenberg", 46.7722, 14.5671, 622, 24.00);
        District kefermarkt = new District("Kefermarkt", 48.443, 14.5384, 2138, 14.18);
        District koenigswiesen = new District("Koenigswiesen", 48.4057, 14.8388, 3091, 11.56);
        District lasberg = new District("Lasberg", 48.4714, 14.5408, 2796, 16.01);
        District leopoldschlag = new District("Leopoldschlag", 48.6159, 14.5036, 1015, 29.77);
        District liebenau = new District("Liebenau", 48.532, 14.8052, 1585, 10.64);
        District neumarkt = new District("Neumarkt", 48.4283, 14.4845, 3163, 14.23);
        District pierbach = new District("Pierbach", 48.3482, 14.7565, 1016, 29.77);
        District pregarten = new District("Pregarten", 48.355, 14.5308, 5422, 16.81);
        District rainbach = new District("Rainbach", 48.5576, 14.4765, 2989, 13.86);
        District sandl = new District("Sandl", 48.5604, 14.6444, 1413, 20.95);
        District schoenau = new District("Schoenau", 48.3942, 14.7291, 1949, 28.34);
        District sanktLeonhard = new District("St. Leonhard", 48.4436, 14.6776, 1388, 23.67);
        District sanktOswald = new District("St. Oswald", 48.5006, 14.5877, 2906, 16.89);
        District tragwein = new District("Tragwein", 48.332, 14.6212, 3099, 21.09);
        District unterweissenbach = new District("Unterweissenbach", 46.9516, 15.8625, 2174, 21.44);
        District unterweitersdorf = new District("Unterweitersdorf", 48.3673, 14.4689, 2161, 19.21);
        District waldburg = new District("Waldburg", 48.509, 14.439, 1382, 15.27);
        District wartberg = new District("Wartberg ob der Aist", 48.3503, 14.5082, 4276, 18.00);
        District weitersfelden = new District("Weitersfelden", 48.4779, 14.7265, 1047, 19.19);
        District windhaag = new District("Windhaag", 48.5862, 14.5615, 1567, 29.77);

        DisrictArr[0] = freistadt;
        DisrictArr[1] = pregarten;
        DisrictArr[2] = wartberg;
        DisrictArr[3] = neumarkt;
        DisrictArr[4] = tragwein;
        DisrictArr[5] = koenigswiesen;
        DisrictArr[6] = rainbach;
        DisrictArr[7] = badZell;
        DisrictArr[8] = sanktOswald;
        DisrictArr[9] = lasberg;
        DisrictArr[10] = hagenberg;
        DisrictArr[11] = gutau;
        DisrictArr[12] = unterweissenbach;
        DisrictArr[13] = unterweitersdorf;
        DisrictArr[14] = kefermarkt;
        DisrictArr[15] = schoenau;
        DisrictArr[16] = gruenbach;
        DisrictArr[17] = liebenau;
        DisrictArr[18] = windhaag;
        DisrictArr[19] = sandl;
        DisrictArr[20] = sanktLeonhard;
        DisrictArr[21] = waldburg;
        DisrictArr[22] = hirschbach;
        DisrictArr[23] = weitersfelden;
        DisrictArr[24] = pierbach;
        DisrictArr[25] = leopoldschlag;
        DisrictArr[26] = kaltenberg;
    }
}
