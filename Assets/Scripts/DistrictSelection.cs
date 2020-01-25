using System;
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
    public Button[] allButtons;
    public PinchableScrollRect scrollRect;
    public District[] districts;
    public static District selectedDistrict;

    /// <summary>
    /// display district name, deactivate buttons for locked levels
    /// </summary>
    void Start()
    {
        districts = DistrictArray.GetAllDistricts();
        if(curDistrict == 0)
        {
            curDistrict = 1;
        }
        
        hideDistricts();
        SetOnClickListener();
    }

    void hideDistricts()
    {
        for (int i = districts.Length; i > curDistrict; i--)
        {
            button = GameObject.Find(districts[i-1].name);
            button.GetComponent<Button>().interactable = false;
        }
    }

    void SetOnClickListener()
    {
        foreach(var btn in allButtons)
        {
            btn.onClick.AddListener(SetClickedDistrict);
        }
    }

    public void SetClickedDistrict()
    {
        int selected = Convert.ToInt32(EventSystem.current.currentSelectedGameObject.tag);
        selectedDistrict = districts[selected-1];
        districtName.text = selectedDistrict.name;
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

