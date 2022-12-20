using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    public Stats Player;
    public WeapownSetting wSetting;
    public ShildSo shiled;
    public CharacterMemory chmemory;
    public List<Stats> setList;

    [SerializeField]
    GameObject setContent;

    [SerializeField]
    GameObject profilePrefab;

    List<Simulator> useEnemy = new List<Simulator>();
    Simulator usePlayer = new Simulator();

    public Text tName;
    public Text tHp;
    public Text tAtk;
    public Text tDef;
    public Text tBdef;
    public Text tAtkSpd;
    public Text tSpd;
    public Text tAtkRange;
    public Text tBld;
    public Text tWep;
    public Text tShield;
    public Text tExp;
    public Text tLv;

    [SerializeField]
    GameObject TestRoom;

    private void Awake()
    {
        usePlayer = GetComponent<Simulator>();
    }


    public void TestAdd(int set)
    {
        if (FindObjectOfType<GameManager>().isTestRoom)
        {
            if (Player.chName == "")
            {
                Player = chmemory.chList[set];
                UpdatePlayer();
            }
            else
            {
                setList.Add(chmemory.chList[set]);
                UpdateEnemy(set);
            }
        }
    }

    public void UpdatePlayer()
    {
        wepownStats nowWeapown = new wepownStats();
        ShildDataSO shieldData = new ShildDataSO();

        for(int i = 0; i<wSetting.wepownStats.Count; i++)
        {
            if(wSetting.wepownStats[i].Wname == Player.weapown)
            {
                nowWeapown = wSetting.wepownStats[i];
            }
        }

        for (int i = 0; i < shiled.shildSOs.Count; i++)
        {
            if (shiled.shildSOs[i].name == Player.shiled)
            {
                shieldData = shiled.shildSOs[i];
            }
        }


        tName.text = Player.chName;
        tHp.text = "체력 :" + (Player.hp + nowWeapown.hp + shieldData.hp).ToString();
        tAtk.text = "ATK :" + (Player.atk + nowWeapown.atk + shieldData.atk).ToString();
        tDef.text = "DEF :" + (Player.def + nowWeapown.def + shieldData.def).ToString();
        tBdef.text = "B-DEF :" + (Player.bdef + nowWeapown.bdef + shieldData.bdef).ToString();
        tAtkSpd.text = "ATK_SPD :" + (Player.atkspd + nowWeapown.atkTime + shieldData.aktspd).ToString();
        tSpd.text = "SPD :" + (Player.walkspd + nowWeapown.spd + shieldData.spd).ToString();
        tAtkRange.text = "ATK_RANGE :" + (Player.atkScale + nowWeapown.atkRange + shieldData.atkRange).ToString();
        tBld.text = "BLD :" + (Player.bdrain + nowWeapown.blode + shieldData.blode).ToString();
        tWep.text = "WEP :" + Player.weapown;
        tShield.text = "WEP :" + Player.shiled;
        tExp.text = "EXP :" + Player.exp.ToString();
        tLv.text = "LV :" + Player.lv.ToString();

        usePlayer.useStats.chName = Player.chName;
        usePlayer.useStats.hp = (Player.hp + nowWeapown.hp + shieldData.hp);
        usePlayer.useStats.atk = (Player.atk + nowWeapown.atk + shieldData.atk);
        usePlayer.useStats.def = (Player.def + nowWeapown.def + shieldData.def);
        usePlayer.useStats.bdef = (Player.bdef + nowWeapown.bdef + shieldData.bdef);
        usePlayer.useStats.atkspd = (Player.atkspd + nowWeapown.atkTime + shieldData.aktspd);
        usePlayer.useStats.walkspd = (Player.walkspd + nowWeapown.spd + shieldData.spd);
        usePlayer.useStats.atkScale = (Player.atkScale + nowWeapown.atkRange + shieldData.atkRange);
        usePlayer.useStats.bdrain = (Player.bdrain + nowWeapown.blode + shieldData.blode);

        usePlayer.Target = new List<Simulator>();
    }

    public void CLSPlayer()
    {
        Player = new Stats();
  
        tName.text = "";
        tHp.text = "체력 :";
        tAtk.text = "ATK :";
        tDef.text = "DEF :";
        tBdef.text = "B-DEF :";
        tAtkSpd.text = "ATK_SPD :";
        tSpd.text = "SPD :";
        tAtkRange.text = "ATK_RANGE :";
        tBld.text = "BLD :";
        tWep.text = "WEP :";
        tShield.text = "WEP :";
        tExp.text = "EXP :";
        tLv.text = "LV :";

        Player.chName = "";
    }

    public void UpdateEnemy(int useIndex)
    {
        GameObject set = Instantiate(profilePrefab);
        set.transform.parent = setContent.transform;
        set.transform.position = Vector3.zero;
        set.transform.localScale = new Vector3(1, 1, 1);
        set.AddComponent<Simulator>().useStats = GetComponent<DataSetting>().soBase.chList[useIndex];
        set.GetComponentInChildren<Text>().text = setList[setList.Count-1].chName;
        useEnemy.Add(set.GetComponent<Simulator>());
    }

    public void CLSEnemy()
    {
        setList.Clear();
        for(int i = 1; i< setContent.GetComponentsInChildren<Transform>().Length; i++)
        {
            Destroy(setContent.GetComponentsInChildren<Transform>()[i].gameObject);
        }
    }

    public void RoomIN()
    {
        for (int i = 0; i<useEnemy.Count; i++)
        {
            Debug.Log(usePlayer.Target);
            usePlayer.Target.Add(useEnemy[i]);
            if (useEnemy[i].Target.Count == 0)
            {
                useEnemy[i].Target.Add(new Simulator());
                useEnemy[i].Target[0] = usePlayer;
                StartCoroutine(useEnemy[i].SimulatorOn());
            }
        }
        usePlayer.StartCoroutine(usePlayer.SimulatorOn());
        TestRoom.SetActive(true);
    }

}
