using System;
using System.Collections;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

// returns current location data of the device (coordinates in latitude, longitude and timestamp)
public class LocationService : MonoBehaviour
{
    public static double LAT;
    public static double LON;
    public float TIME;
    public bool checkSun;
    public double sunrise;
    public double sunset;

    public static string City;
    public static string Clouds;

    private const string APPID = "1fd19b4506a1e2fc4127a81babde32e9";
    public Text location;

    public static int levelDifficulty;
    public Text difficulty;


    public void Start()
    {
        //StartCoroutine(GetDeviceLocation());
        //location.text = "!! " + City + ": " + Clouds + ", " + sunrise + ", " + sunset;
    }

    // Get current time from device, if that fails get Unity frame time
    public DateTime SetTime()
    {
        if (checkSun == true)
        {
            return DateTime.Now;
        }
        return DateTime.Today;
    }

    private double GetDayTimeHours()
    {
        return sunset - sunrise;
    } // GetDayTimeHours method

    public IEnumerator GetDeviceLocation()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            location.text = "FIRST BREAK"; yield break;
        }
        else
        {
            location.text = "ENABLED";
            // Start service before querying location
            Input.location.Start(1, 0.5f);

            // Wait until service initializes
            int maxWait = 5000;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                location.text = "WAITING " + maxWait;
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            // Service didn't initialize in 5 seconds
            if (Input.location.status == LocationServiceStatus.Initializing && maxWait == 1)
            {
                location.text = "well we're stuck";
            }

            // Connection has failed
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                location.text = "device location?? not available";
                yield break;
            }

            // Connection was successful
            if (Input.location.status == LocationServiceStatus.Running)
            {
                // Access granted and location value could be retrieved
                location.text = Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.timestamp;
                // location.text = "RUNNING";
                LAT = Input.location.lastData.latitude;
                if(LAT == 0)
                {
                    LAT = 48.5113;
                }
                LON = Input.location.lastData.longitude;
                if(LON == 0)
                {
                    LON = 14.5048;
                }
                //TIME = Input.location.lastData.timestamp;

                GetWeatherData();
            }
            // Stop service if there is no need to query location updates continuously
            Input.location.Stop();
        }
    } // GetDeviceLocation method

    // reqeust to openweathermap with key stored in APPID variable
    private void GetWeatherData()
    {
        using (WebClient webClient = new WebClient())
        {
            // https://api.openweathermap.org/data/2.5/weather?lat=48.5113&lon=14.5048&APPID=1fd19b4506a1e2fc4127a81babde32e9
            string url = string.Format("https://api.openweathermap.org/data/2.5/weather?lat=" + LAT + "&lon=" + LON + "&APPID=" + APPID);
            var json = webClient.DownloadString(url);
            var result = JSON.Parse(json);

            Clouds = result["clouds"]["all"].Value;
            City = result["name"].Value;
            string tempStr = result["main"]["temp"].Value;
            string sunriseStr = result["sys"]["sunrise"].Value;
            string sunsetStr = result["sys"]["sunset"].Value;
            sunrise = double.Parse(sunriseStr);
            sunset = double.Parse(sunsetStr);
        }

        //delete later, in case it's night while testing
        //checkSun = true;
        // ----

        if (checkSun == true)
        {
            if (Clouds != null)
            {
                int cloudy = int.Parse(Clouds);
                if (cloudy >= 0 && cloudy <= 33)
                {
                    difficulty.text = "Level: Easy, " + City + ": " + Clouds;
                    levelDifficulty = 1;
                }
                if (cloudy > 33 && cloudy <= 66)
                {
                    difficulty.text = "Level: Middle, " + City + ": " + Clouds;
                    levelDifficulty = 2;
                }
                if (cloudy > 66 && cloudy <= 100)
                {
                    difficulty.text = "Level: Hard, " + City + ": " + Clouds;
                    levelDifficulty = 3;
                }
            }
        }
        else
        {
            levelDifficulty = 4;
            difficulty.text = "Level: NIGHT " + City + ": " + Clouds;
        }

    } // GetWeatherData method
}

