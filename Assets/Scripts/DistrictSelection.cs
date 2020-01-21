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

    /// <summary>
    /// display district name, deactivate buttons for locked levels
    /// </summary>
    void Start()
    {
        districts = DistrictArray.GetAllDistricts();

        curDistrict = 1;
        SetDistrictTag();
 
        //for (int i = 27; i > unlockedDistricts; i--)
        //{
        //    button = GameObject.Find(districts[i - 1].Name);         //    button.GetComponent<Image>().color = Color.gray;         //    button.GetComponent<Button>().interactable = false;
        //}
        //Debug.Log("curdistr " + curDistrict);    
    }

    public void SetDistrictTag()
    {
        string tag = EventSystem.current.currentSelectedGameObject.tag;
        curDistrict = int.Parse(tag) - 1;
        Debug.Log("int tag: " + curDistrict);
        districtName.text = DistrictArray.GetDistrict(curDistrict).Name;
        LevelSelection.districtName = EventSystem.current.currentSelectedGameObject.name;
    }

    public void ActivateAllButtons()
    {
        foreach(Button b in allButtons)
        {
            b.interactable = true;
        }
    }

    public void DeactivateAllButtons()
    {
        foreach (Button b in allButtons)
        {
            b.interactable = false;
        }
    } 
}

