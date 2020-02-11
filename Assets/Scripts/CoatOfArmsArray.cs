using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoatOfArmsArray : MonoBehaviour
{
    private static int DistrictNumber = 27;
    public Sprite[] CoatOfArmsArr = new Sprite[DistrictNumber];
    public Image coatOfArmsImg;


    public Sprite GetCoatOfArms(int _index)
    {
        return CoatOfArmsArr[_index];
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "DistrictSelect")
        {
           // coatOfArmsImg.sprite = GetCoatOfArms(DistrictSelection.curDistrict);
           // Debug.Log("coat of arms: " + DistrictSelection.curDistrict);
        }
        if (SceneManager.GetActiveScene().name == "LevelSelect")
        {
            coatOfArmsImg.sprite = GetCoatOfArms(LevelSelection.districtNum);
        }
    }

    public void SetCoatOfArms()
    {
        coatOfArmsImg.sprite = GetCoatOfArms(DistrictSelection.curDistrict);
        Debug.Log("coat of arms: " + DistrictSelection.curDistrict);
    }
}