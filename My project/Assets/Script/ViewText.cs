using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewText : MonoBehaviour
{
    [SerializeField]
    Text tName;
    [SerializeField]
    Text tHp;
    [SerializeField]
    Text tAtk;
    [SerializeField]
    Text tDef;
    [SerializeField]
    Text tBDef;
    [SerializeField]
    Text tSpd;
    [SerializeField]
    Text tAtkRange;
    [SerializeField]
    Text tBld;
    [SerializeField]
    Text tWep;
    [SerializeField]
    Text tSld;
    [SerializeField]
    Text tExp;
    [SerializeField]
    Text tLv;

    [SerializeField]
    CharacterMemory chMemory;
    [SerializeField]
    ShildSo shildSO;
    [SerializeField]
    WeapownSetting weSetting;


    public void PrintText(int id)
    {
        tName.text = chMemory.chList[id].chName;
        tHp.text = chMemory.chList[id].hp.ToString();
        tAtk.text = chMemory.chList[id].atk.ToString();
        tDef.text = chMemory.chList[id].def.ToString();
        tBDef.text = chMemory.chList[id].bdef.ToString();
        tSpd.text = chMemory.chList[id].walkspd.ToString();
        tAtk.text = chMemory.chList[id].atkScale.ToString();
        tBld.text = chMemory.chList[id].bdrain.ToString();
        tWep.text = chMemory.chList[id].weapown;
        tSld.text = chMemory.chList[id].shiled;
        tLv.text = chMemory.chList[id].lv.ToString();
        tExp.text = chMemory.chList[id].exp.ToString();
    }
}
