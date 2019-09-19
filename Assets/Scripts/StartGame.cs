using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public static int coins;
    public Text coinText;

    // Start is called before the first frame update
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
