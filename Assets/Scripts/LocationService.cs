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
    public DateTime time;

    Board board;
    public string City;
    public string Clouds;

    private const string APPID = "1fd19b4506a1e2fc4127a81babde32e9";
    public Text location;
    public AllMonths allMonths;
    public int levelDifficulty;
    public int neededScore;
    public int currentDistrict;

    public void SetUpBoard()
    {
        GameObject boardObject = GameObject.Find("Board");
        board = boardObject.GetComponent<Board>();

        currentDistrict = DistrictSelection.curDistrict;
    }

    public IEnumerator GetDeviceLocation()
    {
        SetDefaultCoords();
        SetUpBoard();
        if (!Input.location.isEnabledByUser)
        {
            location.text = "SERVICE NOT ENABLED";
            board.Setup(7, 7, 20, 15, 6);
            yield break;
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
                SetLevelDifficulty();
                SetNeededScore();
                location.text = City + ": " + Clouds;
                board.Setup(7, 7, 20, neededScore, levelDifficulty);
            }
            // Stop service if there is no need to query location updates continuously
            Input.location.Stop();
        }
    } // GetDeviceLocation method

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
            sunset = UnixTimestampToDateTime(sunsetStr);
        }
    } // GetWeatherData method

    public void SetLevelDifficulty()
    {
        SetCheckSun();
        float dailyTotal = GetDailyTotal();
        if (CHECKSUN == true)
        {
            if (Clouds != null)
            {
                int cloudy = int.Parse(Clouds);
                if (cloudy >= 0 && cloudy <= 20)
                {
                    levelDifficulty = 1;
                }
                else if (cloudy > 21 && cloudy <= 40)
                {
                    levelDifficulty = 2;
                }
                else if (cloudy > 41 && cloudy <= 60)
                {
                    levelDifficulty = 3;
                }
                else if (cloudy > 61 && cloudy <= 80)
                {
                    levelDifficulty = 4;
                }
                else if (cloudy > 81 && cloudy <= 100)
                {
                    levelDifficulty = 5;
                }
            }
        }
        else
        {
            levelDifficulty = 6;
        }
    } // SetLevelDifficulty method

    public void SetNeededScore()
    {
        if (currentDistrict <= 5)
        {
            neededScore = 12;
        }
        else if (currentDistrict <= 10)
        {
            neededScore = 15;
        }
        else if (currentDistrict <= 15)
        {
            neededScore = 18;
        }
        else if (currentDistrict <= 20)
        {
            neededScore = 21;
        }
        else if (currentDistrict <= 25)
        {
            neededScore = 24;
        }
        else
        {
            neededScore = 27;
        }
    } // SetNeededScore;

    private void SetDefaultCoords()
    {
        if (LAT == 0)
        {
            LAT = 48.5113;
        }
        if (LON == 0)
        {
            LON = 14.5048;
        }
        levelDifficulty = 6;
    } // SetDefaultCoords method

    private void SetCheckSun()
    {
        DateTime localDate = DateTime.Now;
        if (localDate > sunrise && localDate < sunset)
        {
            CHECKSUN = true;
        }
        else
        {
            // CHANGE TO True FOR TESTING PURPOSES
            CHECKSUN = true;
        }
    } // SetCheckSun method

    private DateTime UnixTimestampToDateTime(string _unixTimestamp)
    {
        // Unix timestamp is seconds past epoch
        double timestamp = int.Parse(_unixTimestamp);
        DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(timestamp).ToLocalTime();
        return dtDateTime;
    } // UnixTimestampToDateTime method

    private float GetDayTimeHours()
    {
        double sunriseHour = sunrise.Hour;
        double sunriseMinutes = (sunriseHour * 60) + sunrise.Minute;
        double sunriseSeconds = (sunriseMinutes * 60) + sunrise.Second;

        double sunsetHour = sunset.Hour;
        double sunsetMinutes = (sunsetHour * 60) + sunset.Minute;
        double sunsetSeconds = (sunsetMinutes * 60) + sunset.Second;

        double dayTimeSeconds = (sunsetSeconds - sunriseSeconds);
        float dayTimeMinutes = (float)(dayTimeSeconds / 60);
        float dayTimeHours = dayTimeMinutes / 60;
        return dayTimeHours;
    } // GetDayTimeHours method

    public MonthObject GetMonth(int _month)
    {
        allMonths = new AllMonths();
        return allMonths.GetMonth(_month - 1);
    } // GetMonth method

    public float GetDailyTotal()
    {
        float hoursInADay = GetDayTimeHours();
        int month = DateTime.Now.Month;
        MonthObject monthObj = GetMonth(month);

        // sonnenstunden = durchschnittliche sonnenstunden in % für monat x tageslaenge
        float sunFactor = (float)monthObj.SunFactor;
        float sunHours = sunFactor * hoursInADay;

        // tagessumme = wolkengrad x sonnenstunden
        float clouds = float.Parse(Clouds);
        if (clouds == 0)
        {
            return sunHours;
        }
        else
        {
            return sunHours * clouds;
        }
    }  // GetDailyTotal method
}

