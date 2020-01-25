using UnityEngine;

public static class DistrictArray
{
    public static District[] districtArr;
    private static int DistrictNumber = 27;

    public static District[] GetAllDistricts()
    {
        if (districtArr == null)
        {
            SetAllDistricts();
        }
        return districtArr;
    }

    public static District GetDistrict(int _index)
    {
        if (districtArr == null)
        {
            SetAllDistricts();
        }

        if(_index == 0 && Board.isMultiplayer)
        {
            _index = 1;
        }
        Debug.Log(_index);
        if (Board.isMultiplayer)
        {
            return districtArr[0];
        }
        return districtArr[_index];
    }

    /// <summary>
    /// Einwohnerzahlen von Statistik Austria, Stand: Jänner 2019
    /// Photovoltaik / 1000 Einwohner Statistik Austria (ATLAS), Stand: Oktober 2019
    /// </summary>
    private static void SetAllDistricts()
    { 
        //Name, PLZ, area, residents, elevation, lat, lon, pvs
        District freistadt = new District("Freistadt", "4240", 12.86f, 7960, 560, 48.5113, 14.5048, 12.39);
        District pregarten = new District("Pregarten", "4230", 27.77f, 5422, 425, 48.355, 14.5308, 16.81);
        District wartberg = new District("Wartberg ob der Aist", "4224", 19.41f, 4276, 477, 48.3503, 14.5082, 18.00);
        District neumarkt = new District("Neumarkt", "4212", 46.67f, 3163, 632, 48.4283, 14.4845, 14.23);
        District tragwein = new District("Tragwein", "4284", 39.47f, 3099, 491, 48.332, 14.6212, 21.09);
        District koenigswiesen = new District("Königswiesen", "4280", 73.38f, 3091, 614, 48.4057, 14.8388, 11.56);
        District rainbach = new District("Rainbach", "4261", 49.27f, 2989, 719, 48.5576, 14.4765, 13.86);
        District badZell = new District("Bad Zell", "4283", 45.52f, 2913, 515, 48.3496, 14.6686, 20.55);
        District sanktOswald = new District("St. Oswald", "4271", 40.98f, 2906, 608, 48.5006, 14.5877, 16.89);
        District lasberg = new District("Lasberg", "4291", 43.80f, 2796, 574, 48.4714, 14.5408, 16.01);
        District hagenberg = new District("Hagenberg", "4232", 15.05f, 2751, 444, 48.3674, 14.5169, 12.06);
        District gutau = new District("Gutau", "4293", 45.28f, 2672, 589, 48.4184, 14.6122, 22.39);
        District unterweissenbach = new District("Unterweißenbach", "4273", 48.73f, 2174, 640, 46.9516, 15.8625, 21.44);
        District unterweitersdorf = new District("Unterweitersdorf", "4210", 11.42f, 2161, 333, 48.3673, 14.4689, 19.21);
        District kefermarkt = new District("Kefermarkt", "4292", 27.81f, 2138, 516, 48.443, 14.5384, 14.18);
        District schoenau = new District("Schönau", "4274", 38.54f, 1949, 635, 48.3942, 14.7291, 28.34);
        District gruenbach = new District("Grünbach", "4264", 36.08f, 1924, 721, 48.5365, 14.5365, 13.12);
        District liebenau = new District("Liebenau", "4252", 76.31f, 1585, 970, 48.532, 14.8052, 10.64);
        District windhaag = new District("Windhaag", "4263", 42.83f, 1567, 723, 48.5862, 14.5615, 29.77);
        District sandl = new District("Sandl", "4251", 58.32f, 1413, 927, 48.5604, 14.6444, 20.95);
        District sanktLeonhard = new District("St. Leonhard", "4294", 35.01f, 1388,810, 48.4436, 14.6776, 23.67);
        District waldburg = new District("Waldburg", "4240", 26.53f, 1382, 685, 48.509, 14.439, 15.27);
        District hirschbach = new District("Hirschbach", "4242", 23.63f, 1202, 640, 48.4883, 14.4113, 29.77);
        District weitersfelden = new District("Weitersfelden", "4272", 43.72f, 1047, 733, 48.4779, 14.7265, 19.19);
        District pierbach = new District("Pierbach", "4282", 22.72f, 1016, 494, 48.3482, 14.7565, 29.77);
        District leopoldschlag = new District("Leopoldschlag", "4262", 25.80f, 1015, 630, 48.6159, 14.5036, 29.77);
        District kaltenberg = new District("Kaltenberg", "4273", 17.20f, 622, 842, 46.7722, 14.5671, 24.00);
       

        districtArr = new District[27] { freistadt, pregarten, wartberg, neumarkt, tragwein,
        koenigswiesen, rainbach, badZell, sanktOswald, lasberg, hagenberg, gutau, unterweissenbach, unterweitersdorf,
        kefermarkt, schoenau, gruenbach, liebenau, windhaag, sandl, sanktLeonhard, waldburg, hirschbach,
        weitersfelden, pierbach, leopoldschlag, kaltenberg};
    }
}
