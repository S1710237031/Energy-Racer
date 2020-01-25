using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// manages the level selection scene
/// </summary>
public class LevelSelection : MonoBehaviour
{
    public GameObject button;
    public Text districtText;
    public GameObject coatOfArms;
    public Text rowName, rowVal;

    private District selectedDistr;


    // Start is called before the first frame update
    void Start()
    {
        selectedDistr = DistrictSelection.selectedDistrict;
        if (selectedDistr == null)
        {
            districtText.text = "error";
        }
        districtText.text = selectedDistr.name;

        rowName.text = "Postleitzahl \nFlaeche \nEinwohner \nHoehe \nPhotovoltaik pro Einwohner";

        int index = DistrictSelection.curDistrict;
        string values = selectedDistr.zipCode + "\n" +
            selectedDistr.GetAreaString() + "\n" +
            selectedDistr.residents + "\n" +
            selectedDistr.GetElevationString() + "\n" +
            selectedDistr.pvs;
        rowVal.text =
            values;
    }
}
