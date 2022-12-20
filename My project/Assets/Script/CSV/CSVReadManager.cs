using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVReadManager : MonoBehaviour
{
    List<Dictionary<string, object>> chData = new List<Dictionary<string, object>>();
    List<Dictionary<string, object>> wepownData = new List<Dictionary<string, object>>();
    List<Dictionary<string, object>> ShiledData = new List<Dictionary<string, object>>();
    List<Dictionary<string, object>> skillData = new List<Dictionary<string, object>>();

    [SerializeField]
    CharacterMemory chMemory;
    [SerializeField]
    ShildSo shiledSo;
    [SerializeField]
    WeapownSetting weapownSetting;

    private void Start()
    {
        chData = CSVReader.Read("characterSheet");
        wepownData = CSVReader.Read("wepownDataSheet");
        ShiledData = CSVReader.Read("ShiledDataSheet");
        skillData = CSVReader.Read("skillDataSheed");
    }

    void DataSetting()
    {
        chMemory.chList.Clear();
        shiledSo.shildSOs.Clear();
        weapownSetting.wepownStats.Clear();

        for(int i = 1; i<chData.Count; i++)
        {
            Stats currentstat = new Stats();
            currentstat.chName = chData[i]["ID"].ToString();
            currentstat.hp = int.Parse(chData[i]["maxHP"].ToString());
            currentstat.atk = int.Parse(chData[i]["atk"].ToString());
            currentstat.def = int.Parse(chData[i]["def"].ToString());
            currentstat.atkspd = float.Parse(chData[i]["atkSpd"].ToString());
            currentstat.walkspd = float.Parse(chData[i]["spd"].ToString());
            currentstat.bdrain = float.Parse(chData[i]["bdrain"].ToString());
            currentstat.weapown = chData[i]["wepown"].ToString();
            currentstat.shiled = chData[i]["shiled"].ToString();
            currentstat.exp = float.Parse(chData[i]["exp"].ToString());
            currentstat.lv = int.Parse(chData[i]["lv"].ToString());
        }

        for(int i = 0; i<wepownData.Count; i++)
        {
            wepownStats currentstat = new wepownStats();
            currentstat.Wname = wepownData[i]["name"].ToString();
            currentstat.ID = wepownData[i]["weaponName"].ToString();
            currentstat.hp = int.Parse(wepownData[i]["hp"].ToString());
            currentstat.atk = int.Parse(wepownData[i]["atk"].ToString());
            currentstat.def = int.Parse(wepownData[i]["def"].ToString());
            currentstat.aktspd = float.Parse(wepownData[i]["atkspd/%"].ToString());
            currentstat.spd = float.Parse(wepownData[i]["walkSpd"].ToString());
            currentstat.blode = float.Parse(wepownData[i]["bdrain/%"].ToString());
            currentstat.atkRange = float.Parse(wepownData[i]["MaxAtkTarget"].ToString());
            currentstat.Range = float.Parse(wepownData[i]["weaponrange"].ToString());
            currentstat.atkTime = float.Parse(wepownData[i]["cooldown"].ToString());
            currentstat.categori = wepownData[i]["weapontype"].ToString() == "1" ? weapownCategori.Almost : weapownCategori.far;
        }

        for(int i = 0; i<ShiledData.Count; i++)
        {
            ShildDataSO currentstat = new ShildDataSO();
            currentstat.ID = ShiledData[i]["armorID"].ToString();
            currentstat.hp = int.Parse(ShiledData[i]["HP"].ToString());
            currentstat.atk = int.Parse(ShiledData[i]["atk"].ToString());
            currentstat.def = int.Parse(ShiledData[i]["def"].ToString());
            currentstat.aktspd = float.Parse(ShiledData[i]["atkspd/%"].ToString());
            currentstat.spd = float.Parse(ShiledData[i]["walkspd"].ToString());
            currentstat.blode = float.Parse(ShiledData[i]["bldsuk"].ToString());
        }
    }
}
