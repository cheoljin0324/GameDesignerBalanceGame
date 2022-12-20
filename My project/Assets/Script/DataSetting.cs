using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSetting : MonoBehaviour
{
    public CharacterMemory soBase;
    public ShildSo shildSO;
    public WeapownSetting wSetting;

    wepownStats useWeapown;
    ShildDataSO shildDataSO;


    CharacterButtonSet cbtset;

    [Header("이름")]
    [SerializeField]
    InputField chName;
    [Header("체력")]
    [SerializeField]
    InputField hp;
    [Header("공격력")]
    [SerializeField]
    InputField atk;
    [Header("방어력")]
    [SerializeField]
    InputField def;
    [Header("피방어력")]
    [SerializeField]
    InputField bdef;
    [Header("공격 속도")]
    [SerializeField]
    InputField atkspd;
    [Header("이동 속도")]
    [SerializeField]
    InputField walkSpd;
    [Header("공격 범위")]
    [SerializeField]
    InputField atkRange;
    [Header("흡혈")]
    [SerializeField]
    InputField blod;
    [Header("사용 무기")]
    [SerializeField]
    InputField weapown;
    [Header("사용 방어구")]
    [SerializeField]
    InputField shiled;
    [Header("경험치")]
    [SerializeField]
    InputField exp;
    [Header("레벨")]
    [SerializeField]
    InputField lv;

    [Header("이름")]
    [SerializeField]
    Text TName;
    [Header("체력")]
    [SerializeField]
    Text Thp;
    [Header("공격력")]
    [SerializeField]
    Text Tatk;
    [Header("방어력")]
    [SerializeField]
    Text Tdef;
    [Header("피방어력")]
    [SerializeField]
    Text Tbdef;
    [Header("공격 속도")]
    [SerializeField]
    Text Tatkspd;
    [Header("이동 속도")]
    [SerializeField]
    Text TwalkSpd;
    [Header("공격 범위")]
    [SerializeField]
    Text TatkRange;
    [Header("흡혈")]
    [SerializeField]
    Text Tblod;
    [Header("사용 무기")]
    [SerializeField]
    Text Tweapown;
    [Header("사용 방어구")]
    [SerializeField]
    Text Tshiled;
    [Header("경험치")]
    [SerializeField]
    Text Texp;
    [Header("레벨")]
    [SerializeField]
    Text Tlv;


    private void Start()
    {
        cbtset = GetComponent<CharacterButtonSet>();
    }

    public void add()
    {
        Stats newstat = new Stats();
        newstat.chName = chName.text;
        newstat.hp = float.Parse(hp.text);
        newstat.atk = int.Parse(atk.text);
        newstat.def = int.Parse(def.text);
        newstat.bdef = int.Parse(bdef.text);
        newstat.atkspd = float.Parse(atkspd.text);
        newstat.walkspd = float.Parse(walkSpd.text);
        newstat.atkScale = float.Parse(atkRange.text);
        newstat.bdrain = float.Parse(blod.text);
        newstat.weapown = weapown.text;
        newstat.shiled = shiled.text;
        newstat.exp = float.Parse(exp.text);
        newstat.lv = int.Parse(lv.text);

        soBase.chList.Add(newstat);
        cbtset.CharacterSet();

        chName.text = "";
        hp.text = "";
        atk.text = "";
        def.text = "";
        bdef.text = "";
        atkspd.text = "";
        walkSpd.text = "";
        atkRange.text = "";
        blod.text = "";
        weapown.text = "";
        shiled.text = "";
        exp.text = "";
        lv.text = "";
    }

    public void useData(string chName, float hp, int atk, int def, int bdef, float atkspd, float walkspd, float atkScale, float bdrain, string weapown, string shiled, float exp, int lv)
    {

        for(int i = 0; i<wSetting.wepownStats.Count; i++)
        {
            if(weapown == wSetting.wepownStats[i].ID)
            {
                useWeapown = wSetting.wepownStats[i];
            }
        }

        for(int i = 0; i<shildSO.shildSOs.Count; i++)
        {
            if(shiled == shildSO.shildSOs[i].ID)
            {
                shildDataSO = shildSO.shildSOs[i];
            }
        }

        this.chName.text = chName;
        this.hp.text = hp.ToString();
        this.atk.text = atk.ToString();
        this.def.text = def.ToString();
        this.bdef.text = bdef.ToString();
        this.atkspd.text = atkspd.ToString();
        this.walkSpd.text = walkspd.ToString();
        this.atkRange.text = atkScale.ToString();
        this.blod.text = bdrain.ToString();
        this.weapown.text = weapown;
        this.shiled.text = shiled;
        this.exp.text = exp.ToString();
        this.lv.text = lv.ToString();
        TName.text = "이름 :" + chName;
        Thp.text = "체력 :" + (shildDataSO.hp+useWeapown.hp+hp).ToString();
        Tatk.text = "ATK :" + (shildDataSO.atk + useWeapown.atk + atk).ToString();
        Tdef.text = "DEF :" + (shildDataSO.def + useWeapown.def + def).ToString();
        Tbdef.text = "B-DEF :" + (shildDataSO.bdef + useWeapown.bdef + bdef).ToString();
        Tatkspd.text = "ATK_SPD :" + (shildDataSO.aktspd + useWeapown.atkTime+atkspd).ToString()+"%";
        TwalkSpd.text = "SPD :" + (shildDataSO.spd + useWeapown.spd+walkspd).ToString();
        TatkRange.text = "ATK_RANGE :" + (shildDataSO.atkRange + useWeapown.atkRange+atkScale).ToString() + "%";
        Tblod.text = "BLD :" + (shildDataSO.blode + useWeapown.blode+bdrain).ToString() + "%";
        Tweapown.text = "WEP :" + weapown;
        Tshiled.text = "SHD :" + shiled;
        Texp.text = "EXP :" + exp.ToString();
        Tlv.text = "LV :" + lv.ToString();
    }

    public void WepownSet(string ItemId)
    {
        weapown.text = ItemId;
    }

    public void ShiledSet(string ItemID)
    {
        shiled.text = ItemID;
    }
}
