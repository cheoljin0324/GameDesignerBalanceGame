using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Simulator : MonoBehaviour
{
    public Stats useStats;
    public List<Simulator> Target = new List<Simulator>();
    GameManager useFind;


    public IEnumerator SimulatorOn()
    {
        while (Target.Count != 0)
        {
            if(useStats.hp <= 0)
            {
                break;
                StopCoroutine(SimulatorOn());
            }

            if(Target.Count == 0)
            {
                break;
                StopCoroutine(SimulatorOn());
            }


            if (useFind == null)
            {
                useFind = FindObjectOfType<GameManager>();
            }


            yield return new WaitForSeconds(1/useStats.atkspd);


            if (useStats.atkScale < Target.Count)
            {
                for (int i = 0; i < useStats.atkScale; i++)
                {
                    int atk = useStats.atk - (Target[i].useStats.def);
                    if (atk < 0)
                    {
                        atk = 1;
                    }
                    if (useStats.hp <= 0)
                    {
                        break;
                    }
                    Target[i].useStats.hp -= atk;
                    useStats.hp += atk / (1 + useStats.bdrain);
                    madeText(Target[i], 10);
                    yield return new WaitForSeconds(0.1f);
                    if (Target[i].useStats.hp < 0)
                    {
                        Death(Target[i]);
                        Target.RemoveAt(i);
                        Target[i].StopCoroutine(SimulatorOn());
                        break;
                    }
                }
            }
            else
            {

                for (int i = 0; i < Target.Count; i++)
                {
                    int atk = useStats.atk - (Target[i].useStats.def);
                    if (atk < 0)
                    {
                        atk = 1;
                    }
                    if (useStats.hp <= 0)
                    {
                        break;
                    }
                    Target[i].useStats.hp -= atk;
                    useStats.hp += atk / (1 + useStats.bdrain);
                    madeText(Target[i], 10);
                    if (Target[i].useStats.hp <= 0)
                    {
                        Death(Target[i]);
                        Target[i].StopCoroutine(SimulatorOn());
                        Target.RemoveAt(i);
                        break;
                    }
                }
            }
        }
    }

    public void madeText(Simulator target,int damage)
    {
        GameObject useText = Instantiate(useFind.useSimulatorText);
        useText.transform.parent = FindObjectOfType<GameManager>().scrollContentSimul.transform;
        useText.transform.SetAsFirstSibling();
        useText.transform.localScale = new Vector3(1, 1, 1);
        Debug.Log(useStats.chName + "가" + target.useStats.chName + "에게 공격");
        useText.GetComponent<Text>().text = target.useStats.chName + "에게" + damage + "데미지를 줬습니다."+ useStats.atk / (1 + useStats.bdrain)+"만큼 흡혈 했습니다."+"현재 내 HP:"+useStats.hp;  
    }

    public void Death(Simulator target)
    {
        GameObject useText = Instantiate(useFind.useSimulatorText);
        useText.transform.parent = FindObjectOfType<GameManager>().scrollContentSimul.transform;
        useText.transform.SetAsFirstSibling();
        useText.transform.localScale = new Vector3(1, 1, 1);
        useText.GetComponent<Text>().text = target.useStats.chName + "이 사망했습니다";
        return;
    }

    public void GIFT()
    {
        GameObject useText = Instantiate(useFind.useSimulatorText);
        useText.transform.parent = FindObjectOfType<GameManager>().scrollContentSimul.transform;
        useText.transform.SetAsFirstSibling();
        useText.transform.localScale = new Vector3(1, 1, 1);
        useText.GetComponent<Text>().text = "일정 보상을 획득했습니다.";
    }
}
