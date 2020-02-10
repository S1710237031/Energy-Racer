using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class SceneSwitch : MonoBehaviour
{
  //  public static bool backgroundIsSet;

    public void Start()
    {
       // backgroundIsSet = false;
    }

    public void GoToMultiplayerMenu()
    {
        SceneManager.LoadScene("MultiplayerMenu");
    }

    public void GotoGameScene()
    {
        Board.isMultiplayer = SceneManager.GetActiveScene().name == "MultiplayerMenu" || (SceneManager.GetActiveScene().name == "GameWon" && Board.isMultiplayer) || (SceneManager.GetActiveScene().name == "GameOver" && Board.isMultiplayer);

        SceneManager.LoadScene("Game");
    }

    public void GotoGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void GoToWinScene()
    {
        SceneManager.LoadScene("GameWon");
    }

    public void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void GotoLevelSelectScene()
    {
        //LevelSelection.districtName = EventSystem.current.currentSelectedGameObject.name;
        //if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) > DistrictSelection.curDistrict)
        //{
        //    DistrictSelection.curDistrict = int.Parse(EventSystem.current.currentSelectedGameObject.tag);
        //}
        //Debug.Log(EventSystem.current.currentSelectedGameObject.tag);
        SceneManager.LoadScene("LevelSelect");
    }

    public void GoToDistrictSelectScene()
    {
        if (SceneManager.GetActiveScene().name == "GameWon")
        {
            if (DistrictSelection.curDistrict >= DistrictSelection.unlockedDistricts)
                DistrictSelection.unlockedDistricts++;
            StartGame.coins += Board.earnedCoins;
            PlayerPrefs.SetInt("coins", StartGame.coins);
        }

        SceneManager.LoadScene("DistrictSelect");
    }

    public void GoToStartScene()
    {
        if (SceneManager.GetActiveScene().name == "GameWon")
        {
            if (DistrictSelection.curDistrict >= DistrictSelection.unlockedDistricts)
                DistrictSelection.unlockedDistricts++;
            StartGame.coins += Board.earnedCoins;
            PlayerPrefs.SetInt("coins", StartGame.coins);
        }

        SceneManager.LoadScene("StartScene");
    }

    public void GoToShopScene()
    {
        SceneManager.LoadScene("Shop");
    }

    public void GoToLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }
}
