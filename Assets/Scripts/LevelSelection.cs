using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// manages the level selection scene
/// </summary>
public class LevelSelection : MonoBehaviour
{
    public static string districtName;
    public static int districtNum;

    public GameObject button;
    public Text districtText;
    public GameObject coatOfArms;
    public Text lat, lon, area, residents, pvas;

    // Start is called before the first frame update
    void Start()
    {
        if (districtName == null)
        {
            districtName = "Nichts gefunden";
        }
        districtText.text = districtName;
        int index = districtNum;

        pvas.text = "Photovoltaik-Strom (Peak): " + "\n"
            + Math.Round(DistrictArray.DisrictArr[index].PvOutput) + " kW";
        lat.text = "Latitude: " + 
            Math.Round(DistrictArray.DisrictArr[index].Latitude, 2);
        lon.text = "Longitude: " + 
            Math.Round(DistrictArray.DisrictArr[index].Longitude, 2);
        area.text = "Flaeche: " + 
            Math.Round(DistrictArray.DisrictArr[index].Area, 2) + " km²";
        residents.text = "Einwohnerzahl: " 
            + DistrictArray.DisrictArr[index].Residents;
        
    }

    public void SetCoatOfArms()
    {
        coatOfArms = GameObject.Find("CoatOfArms"); 
    }
}
