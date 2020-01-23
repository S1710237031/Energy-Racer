using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScene : MonoBehaviour
{
    public Text winnerText;
    public Text winText;
    public static string winner;
    public Image winnerCarImg;
    public GameObject carCharacter;

    // Start is called before the first frame update
    void Start()
    {
        if (Board.isMultiplayer)
        {
            carCharacter.SetActive(false);
            if (Board.curPlayer == "Player 1")
            {
                winnerCarImg.sprite = MultiplayerMenu.player1Sprite;
            }
            else
            {
                winnerCarImg.sprite = MultiplayerMenu.player2Sprite;
            }
            winnerText.text = Board.curPlayer;
            winText.text = "gewinnt!";
        }
        else
        {
            winnerCarImg.enabled = false;
            winnerText.text = "Du hast";
            winText.text = "gewonnen!";

    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
