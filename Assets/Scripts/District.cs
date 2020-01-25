public class District
{
    public string name { get; set; }
    public string zipCode { get; set; }
    public float area { get; set; }
    public int residents { get; set; }
    public int elevation { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public double pvs { get; set; }

    public District(string _name, string _zipCode, float _area, int _res, int _elevation, double _lat, double _lon, double _pvsPer1000
        )
    {
        name = _name;
        zipCode = _zipCode;
        area = _area;
        latitude = _lat;
        longitude = _lon;
        residents = _res;
        elevation = _elevation;
        pvs = CalculatePVs(_pvsPer1000, _res);
    }

    private double CalculatePVs(double _pvsPer1000, int _res)
    {
        double pvPerSingleResident = _pvsPer1000 / 1000;
        return pvPerSingleResident * _res;
    }

    public string GetAreaString()
    {
        return this.area + "km²";
    }

    public string GetElevationString()
    {
        return this.elevation + "m";

    }

}
