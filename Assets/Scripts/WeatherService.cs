using System;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

/// <summary>
///  returns current location data of the device (coordinates in latitude, longitude and timestamp)
/// </summary>
public class WeatherService : MonoBehaviour
{
    public double LAT;
    public double LON;
    public bool CHECKSUN;
    public DateTime sunrise;
    public DateTime sunset;
    public DateTime time;
    public District[] allDistricts;
    public District curDistrict;
    public int curDistrictNumber;
    Board board;
    public string City;
    public string Clouds;

    private const string APPID = "1fd19b4506a1e2fc4127a81babde32e9";
    public Text location;
    public Text level;

    public static int levelDifficulty;
    private int neededScore;
    private int movesToFinish;


    /// <summary>
    /// sets up game board
    /// </summary>
    public void SetUpBoard()
    {
        GameObject boardObject = GameObject.Find("Board");
        board = boardObject.GetComponent<Board>();
    }

    /// <summary>
    /// gets device location (coordinates) if user permitted
    /// </summary>
    public void SendWeatherRequest()
    {
        SetDefaultCoords();
        SetUpBoard();
        curDistrictNumber = LevelSelection.districtNum;
        DistrictArray.GetAllDistricts();

        curDistrict = DistrictArray.GetDistrict(curDistrictNumber);

        LAT = curDistrict.Latitude;
        LON = curDistrict.Longitude;
        Debug.Log("Coord: " + LAT + "/" + LON);

        GetWeatherData(curDistrict.Latitude, curDistrict.Longitude);
        SetLevelDifficulty();
        SetNeededScore();
        SetMovesToFinish();
        location.text = curDistrict.Name;
        SetLeveLDifficultyText();
        board.Setup(7, 7, movesToFinish, neededScore, levelDifficulty);
    } /// GetDeviceLocation method

    ///<summary>
    /// changes color of level text according to level difficulty 
    ///</summary>
    private Color32 SetLevelTextColor()
    {
        Color32 c = new Color32(0, 0, 0, 255);
        switch (levelDifficulty)
        {
            case 1:
                /// easy = green
                c = new Color32(20, 180, 80, 255);
                break;
            case 2:
                /// less easy = blue
                c = new Color32(66, 160, 222, 255);
                break;
            case 3:
                /// middle = purple
                c = new Color32(166, 66, 222, 255);
                break;
            case 4:
                /// bit harder = orange
                c = new Color32(222, 122, 70, 255);
                break;
            case 5:
                /// hard = red
                c = new Color32(190, 30, 5, 255);
                break;
            default:
                break;
        }
        /// night with level 6 or default = black
        return c;
    }

    ///<summary>
    /// changes level text according to level difficulty, including color
    ///</summary>
    private void SetLeveLDifficultyText()
    {
        switch (levelDifficulty)
        {
            case 1:
                level.text = "Viel Sonne, viel Energie";
                break;
            case 2:
                level.text = "Ein paar Wolken";
                break;
            case 3:
                level.text = "Recht viele Wolken";
                break;
            case 4:
                level.text = "Kaum Sonne, ein bisschen Energie geht noch";
                break;
            case 5:
                level.text = "Keine Sonne, wenig Enerige im Moment";
                break;
            case 6:
                level.text = "Recht dunkel hier, ist gerade Nacht?";
                break;
            default:
                break;
        }
        level.color = SetLevelTextColor();
    }

    /// <summary>
    /// sends request to OpenWeatherMap API for weather data at device location
    /// </summary>
    private void GetWeatherData(double _lat, double _lon)
    {
        using (WebClient webClient = new WebClient())
        {

            /// https://api.openweathermap.org/data/2.5/weather?lat=48.5113&lon=14.5048&APPID=1fd19b4506a1e2fc4127a81babde32e9
            string url = string.Format("https://api.openweathermap.org/data/2.5/weather?lat="
                + _lat + "&lon=" + _lon + "&APPID=" + APPID);
            try
            {
                var json = webClient.DownloadString(url);
                var result = JSON.Parse(json);

                Clouds = result["clouds"]["all"].Value;
                string tempStr = result["main"]["temp"].Value;
                string sunriseStr = result["sys"]["sunrise"].Value;
                sunrise = UnixTimestampToDateTime(sunriseStr);
                string sunsetStr = result["sys"]["sunset"].Value;
                sunset = UnixTimestampToDateTime(sunsetStr);
            }
            catch (WebException ex)
            {
                sunrise = DateTime.Now;
                sunset = DateTime.Now;
                throw ex;
            }
        }
    } /// GetWeatherData method

    public static int GetLevelDifficulty()
    {
        return levelDifficulty;
    }
    /// <summary>
    /// chooses level difficulty according to weather data
    /// </summary>
    public void SetLevelDifficulty()
    {
        SetCheckSun();
        double dailyTotal = GetDailyTotal();
        if (CHECKSUN == true)
        {
            Debug.Log("DAILY TOTAL: " + dailyTotal);
            if (dailyTotal != 0)
            {
                if (dailyTotal < 2978 && dailyTotal >= 2381)
                {
                    levelDifficulty = 1;
                }
                if (dailyTotal < 2381 && dailyTotal >= 1785)
                {
                    levelDifficulty = 2;
                }
                if (dailyTotal < 1785 && dailyTotal >= 1190)
                {
                    levelDifficulty = 3;
                }
                if (dailyTotal < 1190 && dailyTotal >= 595)
                {
                    levelDifficulty = 4;
                }
                if (dailyTotal < 595)
                {
                    levelDifficulty = 5;
                }
            }
        }
        else
        {
            levelDifficulty = 6;
        }
    } /// SetLevelDifficulty method

    /// <summary>
    /// sets moves needed to complete level
    /// </summary>
    private void SetMovesToFinish()
    {
        switch (levelDifficulty)
        {
            case 1:
                movesToFinish = 35;
                break;
            case 2:
                movesToFinish = 33;
                break;
            case 3:
                movesToFinish = 30;
                break;
            case 4:
                movesToFinish = 25;
                break;
            case 5:
                movesToFinish = 20;
                break;
            case 6:
                movesToFinish = 20;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// sets score needed to complete level
    /// </summary>
    private void SetNeededScore()
    {
        switch (levelDifficulty)
        {
            case 1:
                neededScore = 12;
                break;
            case 2:
                neededScore = 15;
                break;
            case 3:
                neededScore = 18;
                break;
            case 4:
                neededScore = 21;
                break;
            case 5:
                neededScore = 24;
                break;
            case 6:
                neededScore = 30;
                break;
            default:
                break;

        }
    } /// SetNeededScore;

    /// <summary>
    /// sets default coordinates in case location goes wrong
    /// </summary>
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
    } /// SetDefaultCoords method

    /// <summary>
    /// checks if it is daytime or not
    /// </summary>
    private void SetCheckSun()
    {
        DateTime localDate = DateTime.Now;
        if (localDate >= sunrise && localDate <= sunset)
        {
            CHECKSUN = true;
        }
        else
        {
            /// should be FALSE, change TO True FOR TESTING PURPOSES
            CHECKSUN = false;
        }
    } /// SetCheckSun method

    /// <summary>
    /// converts UnixTimestamp to unity DateTime format
    /// </summary>
    /// <returns>DateTime object</returns>
    private DateTime UnixTimestampToDateTime(string _unixTimestamp)
    {
        /// Unix timestamp is seconds past epoch
        double timestamp = int.Parse(_unixTimestamp);
        DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(timestamp).ToLocalTime();
        return dtDateTime;
    } /// UnixTimestampToDateTime method

    /// <summary>
    /// sets the average number of hours in a day
    /// depending on the current month
    /// </summary>
    /// <returns>number of hours</returns>
    private double GetDayTimeHours()
    {
        double dayTimeHours = 8;
        switch (DateTime.Now.Month)
        {
            case 1:
                dayTimeHours = 8.5;
                break;
            case 2:
                dayTimeHours = 10;
                break;
            case 3:
                dayTimeHours = 11.5;
                break;
            case 4:
                dayTimeHours = 13.5;
                break;
            case 5:
                dayTimeHours = 15;
                break;
            case 6:
                dayTimeHours = 16;
                break;
            case 7:
                dayTimeHours = 15.5;
                break;
            case 8:
                dayTimeHours = 14;
                break;
            case 9:
                dayTimeHours = 12.5;
                break;
            case 10:
                dayTimeHours = 10.5;
                break;
            case 11:
                dayTimeHours = 9;
                break;
            case 12:
                dayTimeHours = 8;
                break;
            default:
                dayTimeHours = 8.5;
                break;
        }
        return dayTimeHours;
        /**
        double sunriseHour = sunrise.Hour;
        double sunriseMinutes = (sunriseHour * 60) + sunrise.Minute;
        double sunriseSeconds = (sunriseMinutes * 60) + sunrise.Second;

        double sunsetHour = sunset.Hour;
        double sunsetMinutes = (sunsetHour * 60) + sunset.Minute;
        double sunsetSeconds = (sunsetMinutes * 60) + sunset.Second;

        double dayTimeSeconds = (sunsetSeconds - sunriseSeconds);
        float dayTimeMinutes = (float)(dayTimeSeconds / 60);
        float dayTimeHours = dayTimeMinutes / 60;
    */
    } /// GetDayTimeHours method

    /// <summary>
    /// calculates sum of usful daily hours
    /// </summary>
    public double GetDailyTotal()
    {
        /// double dayTime = GetDayTimeHours();
        ///  Debug.Log("dayTime: " + dayTime);
        /// variable sunny = 100 - current cloud percentage
        double howSunny = 100 - double.Parse(Clouds);
        Debug.Log("howSunny: " + howSunny);

        double dailyTotal = howSunny * curDistrict.PVs;
        return dailyTotal;
    }  /// GetDailyTotal method
}

