using UnityEngine;
using UnityEngine.UI;

public class CoatOfArmsArray : MonoBehaviour
{
    private static int DistrictNumber = 27;
    public Sprite[] CoatOfArmsArr = new Sprite[DistrictNumber];


    public Sprite[] GetCoatOfArmsArr()
    {
        return CoatOfArmsArr;
    }

    public Sprite GetCoatOfArm(int _index)
    {
        return CoatOfArmsArr[_index];
    }

    private void SetAllCoatOfArms()
    {
        CoatOfArmsArr[0] = Resources.Load<Sprite>(" /Art/CoatOfArms/0");
        CoatOfArmsArr[1] = Resources.Load<Sprite>(" /Art/CoatOfArms/1");
        CoatOfArmsArr[2] = Resources.Load<Sprite>(" /Art/CoatOfArms/2");
        CoatOfArmsArr[3] = Resources.Load<Sprite>(" /Art/CoatOfArms/3");
        CoatOfArmsArr[4] = Resources.Load<Sprite>(" /Art/CoatOfArms/4");
        CoatOfArmsArr[5] = Resources.Load<Sprite>(" /Art/CoatOfArms/5");
        CoatOfArmsArr[6] = Resources.Load<Sprite>(" /Art/CoatOfArms/6");
        CoatOfArmsArr[7] = Resources.Load<Sprite>(" /Art/CoatOfArms/7");
        CoatOfArmsArr[8] = Resources.Load<Sprite>(" /Art/CoatOfArms/8");
        CoatOfArmsArr[9] = Resources.Load<Sprite>(" /Art/CoatOfArms/9");
        CoatOfArmsArr[10] = Resources.Load<Sprite>(" /Art/CoatOfArms/10");
        CoatOfArmsArr[11] = Resources.Load<Sprite>(" /Art/CoatOfArms/11");
        CoatOfArmsArr[12] = Resources.Load<Sprite>(" /Art/CoatOfArms/12");
        CoatOfArmsArr[13] = Resources.Load<Sprite>(" /Art/CoatOfArms/13");
        CoatOfArmsArr[14] = Resources.Load<Sprite>(" /Art/CoatOfArms/14");

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

}