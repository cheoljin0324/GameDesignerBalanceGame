using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WepownSOArr", menuName = "ScriptableObject/WepownSOArr")]
public class WeapownSetting : ScriptableObject
{
    public List<wepownStats> wepownStats;
}

[System.Serializable]
public struct wepownStats
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
}


public enum weapownCategori
{
    None,Almost,far
}
