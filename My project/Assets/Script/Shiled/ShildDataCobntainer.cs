using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildDataCobntainer : MonoBehaviour
{
    public string Sname;
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

    public void ShildSet()
    {
        FindObjectOfType<DataSetting>().ShiledSet(ID);
    }
}
