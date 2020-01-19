using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        PlayerPrefs.GetInt("coins");
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "$" + coins;
    }
}
