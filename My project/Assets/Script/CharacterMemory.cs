using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSOArr", menuName = "ScriptableObject/CharacterSOArr")]
public class CharacterMemory : ScriptableObject
{
    public List<Stats> chList;
}

[System.Serializable]
public struct Stats
{
    [Header("캐릭터 이름")]
    public string chName;
    [Header("체력")]
    public float hp;
    [Header("공격력")]
    public int atk;
    [Header("방어력")]
    public int def;
    [Header("피 방어력")]
    public int bdef;
    [Header("공속")]
    public float atkspd;
    [Header("이동속도")]
    public float walkspd;
    [Header("공격 범위")]
    public float atkScale;
    [Header("흡혈능력")]
    public float bdrain;
    [Header("사용 무기")]
    public string weapown;
    [Header("사용 방어구")]
    public string shiled;
    [Header("경험치")]
    public float exp;
    [Header("레벨")]
    public int lv;
}
