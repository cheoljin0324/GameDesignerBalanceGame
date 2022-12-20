using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiledDataSet : MonoBehaviour
{
    public ShildSo ShildMemory;
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


        for (int i = 0; i < ShildMemory.shildSOs.Count; i++)
        {
            GameObject playerButton = GameObject.Instantiate(ButtonPrefab, playerScroll.transform);
            playerButton.AddComponent<ShildDataCobntainer>();
            ShildDataCobntainer plCon = playerButton.GetComponent<ShildDataCobntainer>();
            plCon.Sname = ShildMemory.shildSOs[i].name;
            plCon.ID = ShildMemory.shildSOs[i].ID;
            plCon.hp = ShildMemory.shildSOs[i].hp;
            plCon.atk = ShildMemory.shildSOs[i].atk;
            plCon.def = ShildMemory.shildSOs[i].def;
            plCon.aktspd = ShildMemory.shildSOs[i].aktspd;
            plCon.spd = ShildMemory.shildSOs[i].spd;
            plCon.atkRange = ShildMemory.shildSOs[i].atkRange;
            plCon.Range = ShildMemory.shildSOs[i].Range;
            plCon.blode = ShildMemory.shildSOs[i].blode;

            playerButton.GetComponent<Button>().onClick.AddListener(playerButton.GetComponent<ShildDataCobntainer>().ShildSet);
            playerButton.GetComponentInChildren<Text>().text = plCon.Sname;
        }
    }
}
