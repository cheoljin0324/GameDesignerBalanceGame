using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShildeSo", menuName = "ScriptableObject/ShildSo")]
public class ShildSo : ScriptableObject
{
    public List<ShildDataSO> shildSOs;
}

[System.Serializable]
public struct ShildDataSO
{
    public string name;
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
}
