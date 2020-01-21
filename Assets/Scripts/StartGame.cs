using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// manages start scene
/// </summary>
public class StartGame : MonoBehaviour
{
    public static int coins;
    public Text coinText;

    /// <summary>
    /// get the amount of coins from local storage
    /// </summary>
    void Start()
    {
        coins = new int();
        PlayerPrefs.GetInt("coins");
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            int difficulty = LocationService.GetLevelDifficulty();
            SceneBackgroundInformation.SetBackground(difficulty);
            //  backgroundIsSet = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
