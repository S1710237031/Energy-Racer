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
    public Text pointsText;

    // Start is called before the first frame update
    void Start()
    {
        if (Board.isMultiplayer)
        {
            carCharacter.SetActive(false);
            if (Board.curPlayer == "Player 1")
            {
                winnerCarImg.sprite = MultiplayerMenu.player1Sprite;
                pointsText.text = Board.curScore + " Punkte";
            }
            else
            {
                winnerCarImg.sprite = MultiplayerMenu.player2Sprite;
                pointsText.text = Board.curPlayer2Score + " Punkte";
            }
            winnerText.text = Board.curPlayer;
            winText.text = "gewinnt!";
        }
        else
        {
<<<<<<< HEAD
            winnerCarImg.enabled = false;
            winnerText.text = "Du hast";
            winText.text = "gewonnen!";
            pointsText.text = Board.curScore + " Punkte";
=======
            winnerText.text = "Gewonnen!";
            winText.text = "";
>>>>>>> cd7757dfb1eb09fa6645993220e161143440f34e
        }

    }
}
