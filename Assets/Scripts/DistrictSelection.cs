using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DistrictSelection : MonoBehaviour
{
    public Text coinsText;
    public static int coins;
    public static int curDistrict;
    public static int unlockedDistricts;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        coinsText.text = "$" + coins;
        if (unlockedDistricts == 0)
        {
            unlockedDistricts = 1;
        }

        string[] distrNames = {"Freistadt", "Pregarten", "Wartberg",
        "Neumarkt", "Tragwein", "Königswiesen", "Rainbach", "Bad Zell",
        "St. Oswald", "Lasberg", "Hagenberg", "Gutau", "Unterweißenbach", "Unterweitersdorf",
        "Kefermarkt", "Schönau", "Grünbach", "Liebenau", "Windhaag", "Sandl",
        "St. Leonhard", "Waldburg", "Hirschbach", "Weitersfelden", "Pierbach",
        "Leopoldschlag", "Kaltenberg"};

        Debug.Log("curdistr " + curDistrict);

        //deactivate locked districts 
        for (int i = 27; i > unlockedDistricts; i--)
        {
            button = GameObject.Find(distrNames[i - 1]);             button.GetComponent<Button>().interactable = false; 
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}

