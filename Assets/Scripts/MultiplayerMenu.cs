using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerMenu : MonoBehaviour
{

    public Sprite[] availableCars;
    public Button[] carPicker;
    public Text[] playerTextFields;
    public Text titleText;

    // Start is called before the first frame update
    void Start()
    {
        displayCarSelection();
    }

    void displayCarSelection()
    {
        for(int i = 0; i < carPicker.Length; i++)
        {
            carPicker[i].image.sprite = availableCars[i];
        }

        titleText.text = "Autoauswahl";
        playerTextFields[0].text = "Spieler 1";
        playerTextFields[1].text = "Spieler 2";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
