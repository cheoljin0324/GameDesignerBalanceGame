using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WepownDataContainer : MonoBehaviour
{
    public string Wname;
    public string ID;
    public float hp;
    public int atk;
    public int def;
    public int bdef;
    public float aktspd;
    public float spd;
    public float atkRange;
    public float Range;
    public float blode;
    public float atkTime;
    public weapownCategori categori;

    public void WepownSet()
    {
        FindObjectOfType<DataSetting>().WepownSet(ID);
    }
}
