using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SceneSwitch : MonoBehaviour
{

    public void GotoGameScene()
    {
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

    public void GotoLevelSelectScene()
    {
        LevelSelection.districtName = EventSystem.current.currentSelectedGameObject.name;
        if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) > DistrictSelection.curDistrict)
        {
            DistrictSelection.curDistrict = int.Parse(EventSystem.current.currentSelectedGameObject.tag);
        }
        Debug.Log(EventSystem.current.currentSelectedGameObject.tag);
        SceneManager.LoadScene("LevelSelect");
    }

    public void GoToDistrictSelectScene()
    {
        if (SceneManager.GetActiveScene().name == "GameWon")
        {
            if(DistrictSelection.curDistrict >= DistrictSelection.unlockedDistricts)
            DistrictSelection.unlockedDistricts++;
            DistrictSelection.coins += Board.earnedCoins;
        }
        SceneManager.LoadScene("DistrictSelect");
    }

    public void GoToStartScene()
    {

        SceneManager.LoadScene("StartScene");
    }

    public void GoToShopScene()
    {
        SceneManager.LoadScene("Shop");
    }
}
