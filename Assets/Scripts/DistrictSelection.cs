using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// manages the district selection scene
/// </summary>
public class DistrictSelection : MonoBehaviour
{
    public Text districtName;
    public static int curDistrict;
    public static int unlockedDistricts;
    public GameObject button;
    public List<Button> allButtons;
    public PinchableScrollRect scrollRect;
    public District[] districts;

    public Color32 greenColor;
    public Color32 redColor;

    /// <summary>
    /// display district name, deactivate buttons for locked levels
    /// </summary>
    void Start()
    {
        districts = DistrictArray.GetAllDistricts();
        greenColor = new Color32(20, 180, 80, 180);
        redColor = new Color32(222, 122, 70, 180);
    }

    public void SelectDistrictTag()
    {
        string tag = EventSystem.current.currentSelectedGameObject.tag;
        curDistrict = int.Parse(tag) - 1;
        districtName.text = DistrictArray.GetDistrict(curDistrict).Name;
        SetDistrictPanelColor(DistrictArray.GetDistrict(curDistrict).IsOverHalf);
        LevelSelection.districtNum = curDistrict;
        LevelSelection.districtName = EventSystem.current.currentSelectedGameObject.name;
    }

    private void SetButtonHihglightColor(bool _overHalf)
    {
        GameObject content = GameObject.FindGameObjectWithTag("Content");
        if (_overHalf)
        {
            content.GetComponent<Image>().color = greenColor;
        }
        else
        {
            content.GetComponent<Image>().color = redColor;
        }
    }

    private void SetDistrictPanelColor(bool _overHalf)
    {
        GameObject panel = GameObject.FindGameObjectWithTag("DistrictPanel");
        if (_overHalf)
        {
            panel.GetComponent<Image>().color = greenColor;
        }
        else
        {
            panel.GetComponent<Image>().color = redColor;
        }
    }
}

