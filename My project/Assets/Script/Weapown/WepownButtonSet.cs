using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WepownButtonSet : MonoBehaviour
{
    public WeapownSetting weMemory;
    [SerializeField]
    GameObject playerScroll;
    [SerializeField]
    GameObject ButtonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        CharacterSet();
    }

    public void CharacterSet()
    {
        Transform[] Child = playerScroll.GetComponentsInChildren<Transform>();
        if (Child != null)
        {
            for (int i = 0; i < Child.Length; i++)
            {
                if (Child[i] != playerScroll.transform)
                {
                    Destroy(Child[i].gameObject);
                }
            }
        }


        for (int i = 0; i < weMemory.wepownStats.Count; i++)
        {
            GameObject playerButton = GameObject.Instantiate(ButtonPrefab, playerScroll.transform);
            playerButton.AddComponent<WepownDataContainer>();
            WepownDataContainer plCon = playerButton.GetComponent<WepownDataContainer>();
            plCon.Wname = weMemory.wepownStats[i].Wname;
            plCon.ID = weMemory.wepownStats[i].ID;
            plCon.hp = weMemory.wepownStats[i].hp;
            plCon.atk = weMemory.wepownStats[i].atk;
            plCon.def = weMemory.wepownStats[i].def;
            plCon.aktspd = weMemory.wepownStats[i].aktspd;
            plCon.spd = weMemory.wepownStats[i].spd;
            plCon.atkRange = weMemory.wepownStats[i].atkRange;
            plCon.Range = weMemory.wepownStats[i].Range;
            plCon.blode = weMemory.wepownStats[i].blode;
            plCon.atkTime = weMemory.wepownStats[i].atkTime;
            plCon.categori = weMemory.wepownStats[i].categori;

            playerButton.GetComponent<Button>().onClick.AddListener(playerButton.GetComponent<WepownDataContainer>().WepownSet);
            playerButton.GetComponentInChildren<Text>().text = plCon.Wname;
        }
    }
}
