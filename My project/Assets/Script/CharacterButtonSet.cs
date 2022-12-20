using UnityEngine;
using UnityEngine.UI;


public class CharacterButtonSet : MonoBehaviour
{
    public CharacterMemory chMemory;
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
        if(Child != null)
        {
            for(int i = 0; i<Child.Length; i++)
            {
                if(Child[i] != playerScroll.transform)
                {
                    Destroy(Child[i].gameObject);
                }
            }
        }


        for(int i = 0; i<chMemory.chList.Count; i++)
        {
            GameObject playerButton = GameObject.Instantiate(ButtonPrefab, playerScroll.transform);
            playerButton.AddComponent<PlayerDataContainer>();
            PlayerDataContainer plCon = playerButton.GetComponent<PlayerDataContainer>();
            plCon.chName = chMemory.chList[i].chName;
            plCon.hp = chMemory.chList[i].hp;
            plCon.atk = chMemory.chList[i].atk;
            plCon.def = chMemory.chList[i].def;
            plCon.bdef = chMemory.chList[i].bdef;
            plCon.atkspd = chMemory.chList[i].atkspd;
            plCon.walkspd = chMemory.chList[i].walkspd;
            plCon.atkScale = chMemory.chList[i].atkScale;
            plCon.bdrain = chMemory.chList[i].bdrain;
            plCon.weapown = chMemory.chList[i].weapown;
            plCon.shiled = chMemory.chList[i].shiled;
            plCon.exp = chMemory.chList[i].exp;
            plCon.lv = chMemory.chList[i].lv;

            playerButton.GetComponent<Button>().onClick.AddListener(playerButton.GetComponent<PlayerDataContainer>().DataSet);
            FindObjectOfType<GameManager>().buttonIndex++;
            playerButton.GetComponentInChildren<Text>().text = plCon.chName;
        }
        AddON();
    }

    public void AddON()
    {
        for(int i = playerScroll.GetComponentsInChildren<Button>().Length-1; i>=0; i--)
        {
            int index = i;
            playerScroll.GetComponentsInChildren<Button>()[i].onClick.AddListener(() => FindObjectOfType<TestManager>().TestAdd(index));
        }
    }
}
