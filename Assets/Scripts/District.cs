public class District
{
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int Residents { get; set; }
    public double PvOutput { get; set; }
    public double Area { get; set; }
    public bool IsOverHalf { get; set; }

    private static double Max = 681.77;

    public District(string _name, double _lat, double _lon, int _res, double _pvPeakPer1000, double _area)
    {
        Name = _name;
        Latitude = _lat;
        Longitude = _lon;
        Residents = _res;
        PvOutput = CalculateDistrictOutput(_pvPeakPer1000, _res);
        Area = _area;
    }

    private double CalculateDistrictOutput(double _pvPeakPer1000, int _res)
    {
        double districtOutput = (_pvPeakPer1000 / 1000) * _res;
        if ((districtOutput / Max) * 100 >= 50)
        {
            IsOverHalf = true;
        } else
        {
            IsOverHalf = false;
        }
        return districtOutput;
    }

}
