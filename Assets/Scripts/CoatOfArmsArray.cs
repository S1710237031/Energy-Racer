using UnityEngine;
using UnityEngine.UI;

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
        coatOfArmsImg.sprite = GetCoatOfArms(DistrictSelection.curDistrict);
    }

    /**
    CoatOfArmsArr[0] = freistadt;
    CoatOfArmsArr[1] = pregarten;
    CoatOfArmsArr[2] = wartberg;
    CoatOfArmsArr[3] = neumarkt;
    CoatOfArmsArr[4] = tragwein;
    CoatOfArmsArr[5] = koenigswiesen;
    CoatOfArmsArr[6] = rainbach;
    CoatOfArmsArr[7] = badZell;
    CoatOfArmsArr[8] = sanktOswald;
    CoatOfArmsArr[9] = lasberg;
    CoatOfArmsArr[10] = hagenberg;
    CoatOfArmsArr[11] = gutau;
    CoatOfArmsArr[12] = unterweissenbach;
    CoatOfArmsArr[13] = unterweitersdorf;
    CoatOfArmsArr[14] = kefermarkt;
    CoatOfArmsArr[15] = schoenau;
    CoatOfArmsArr[16] = gruenbach;
    CoatOfArmsArr[17] = liebenau;
    CoatOfArmsArr[18] = windhaag;
    CoatOfArmsArr[19] = sandl;
    CoatOfArmsArr[20] = sanktLeonhard;
    CoatOfArmsArr[21] = waldburg;
    CoatOfArmsArr[22] = hirschbach;
    CoatOfArmsArr[23] = weitersfelden;
    CoatOfArmsArr[24] = pierbach;
    CoatOfArmsArr[25] = leopoldschlag;
    CoatOfArmsArr[26] = kaltenberg;
*/

}