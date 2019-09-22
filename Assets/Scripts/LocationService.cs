using System;
using System.Collections;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

// returns current location data of the device (coordinates in latitude, longitude and timestamp)
public class LocationService : MonoBehaviour
{
    public double LAT;
    public double LON;
    public double TIME;
    public bool CHECKSUN;
    public DateTime sunrise;
    public DateTime sunset;

    Board board;
    public string City;
    public string Clouds;

    private const string APPID = "1fd19b4506a1e2fc4127a81babde32e9";
    public Text location;

    public int levelDifficulty;
    // public Text difficulty;

    public void SetUpBoard()
    {
        GameObject boardOjbect = GameObject.Find("Board");
        board = boardOjbect.GetComponent<Board>();
    }

    public IEnumerator GetDeviceLocation()
    {
        SetDefaultCoords();
        SetUpBoard();
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            location.text = "SERVICE NOT ENABLED"; yield break;
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
                location.text = "WAITING";
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            // Service didn't initialize in 5 seconds
            if (Input.location.status == LocationServiceStatus.Initializing && maxWait == 1)
            {
                location.text = "INITIALIZING";
            }

            // Connection has failed
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                location.text = "FAILED";
                yield break;
            }

            // Connection was successful
            if (Input.location.status == LocationServiceStatus.Running)
            {
                // Access granted and location value could be retrieved

                location.text = "RUNNING";
                LAT = Input.location.lastData.latitude;
                LON = Input.location.lastData.longitude;
                TIME = Input.location.lastData.timestamp;

                GetWeatherData(LAT, LON);
                location.text = City + ": " + Clouds;

                board.Setup(7, 7, 20, 6, levelDifficulty);

            }
            // Stop service if there is no need to query location updates continuously
            Input.location.Stop();
        }
    } // GetDeviceLocation method

    // reqeust to openweathermap with key stored in APPID variable
    private void GetWeatherData(double _lat, double _lon)
    {
        using (WebClient webClient = new WebClient())
        {
            // https://api.openweathermap.org/data/2.5/weather?lat=48.5113&lon=14.5048&APPID=1fd19b4506a1e2fc4127a81babde32e9
            string url = string.Format("https://api.openweathermap.org/data/2.5/weather?lat=" + _lat + "&lon=" + _lon + "&APPID=" + APPID);
            var json = webClient.DownloadString(url);
            var result = JSON.Parse(json);


            Clouds = result["clouds"]["all"].Value;
            City = result["name"].Value;
            string tempStr = result["main"]["temp"].Value;
            string sunriseStr = result["sys"]["sunrise"].Value;
            sunrise = UnixTimestampToDateTime(sunriseStr);
            string sunsetStr = result["sys"]["sunset"].Value;
            sunset = sunrise = UnixTimestampToDateTime(sunsetStr);
        }
        SetLevelDifficulty();

    } // GetWeatherData method

    // calculate hours from sunrise to sunset
    private double GetDayTimeHours()
    {
        double sunsetDouble = double.Parse(sunset.ToString("yyyyMMddHHmmss"));
        double sunriseDouble = double.Parse(sunrise.ToString("yyyyMMddHHmmss"));
        return sunsetDouble - sunriseDouble;

    } // GetDayTimeHours method

    // set default coordinates in case weathermap request fails
    private void SetDefaultCoords()
    {
        if (LAT == 0)
        {
            LAT = 48.5113;
        }
        LON = Input.location.lastData.longitude;
        if (LON == 0)
        {
            LON = 14.5048;
        }
    } // SetDefaultCoords method

    // convert unix timestamp (json) to datetime
    private DateTime UnixTimestampToDateTime(string _unixTimestamp)
    {
        // Unix timestamp is seconds past epoch
        double timestamp = int.Parse(_unixTimestamp);
        DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(timestamp).ToLocalTime();
        return dtDateTime;
    } // UnixTimestampToDateTime method

    // chose one of three difficulty levels according to clouds
    private void SetLevelDifficulty()
    {
        SetCheckSun();
        if (CHECKSUN == true)
        {
            if (Clouds != null)
            {
                int cloudy = int.Parse(Clouds);
                if (cloudy >= 0 && cloudy <= 33)
                {
                    //difficulty.text = "Level: Easy, " + City + ": " + Clouds;
                    levelDifficulty = 1;
                }
                if (cloudy > 33 && cloudy <= 66)
                {
                    //difficulty.text = "Level: Middle, " + City + ": " + Clouds;
                    levelDifficulty = 2;
                }
                if (cloudy > 66 && cloudy <= 100)
                {
                    //difficulty.text = "Level: Hard, " + City + ": " + Clouds;
                    levelDifficulty = 3;
                }
            }
        }
        else
        {
            levelDifficulty = 4;
            // difficulty.text = "Level: NIGHT " + City + ": " + Clouds;
        }
    } // SetLevelDifficulty method

    // set bool flag for daytime
    private void SetCheckSun()
    {
        DateTime localDate = DateTime.Now;
        if (localDate > sunrise && localDate < sunset)
        {
            CHECKSUN = true;
        }
        else
        {
            // CHANGE TO FALSE, JUST "TRUE" FOR TESTING PURPOSES
            CHECKSUN = true;
        }
    } // SetCheckSun method
}

