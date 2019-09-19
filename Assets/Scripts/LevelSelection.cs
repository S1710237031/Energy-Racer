using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public GameObject button;
    public Text districtText;
    public static string districtName;


    // Start is called before the first frame update
    void Start()
    {
        if (districtName == null)
        {
            districtName = "error";
        }
        districtText.text = districtName;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
