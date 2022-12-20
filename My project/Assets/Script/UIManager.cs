using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject mainCanvas;
    [SerializeField]
    GameObject playCanvas;
    [SerializeField]
    GameObject playerScroll;
    [SerializeField]
    GameObject weapownScroll;
    [SerializeField]
    GameObject shiledScroll;
    [SerializeField]
    GameObject Input;
    [SerializeField]
    GameObject InputButton;
    [SerializeField]
    GameObject view;
    [SerializeField]
    GameObject TestView;
    [SerializeField]
    GameObject InputText;
    [SerializeField]
    GameObject setTestPanel;
 

    public void SetView()
    {
        mainCanvas.SetActive(false);
        InputText.SetActive(false);
        playCanvas.SetActive(true);
        view.gameObject.SetActive(true);
        weapownScroll.gameObject.SetActive(false);
        shiledScroll.gameObject.SetActive(false);
        Input.gameObject.SetActive(false);
        InputButton.gameObject.SetActive(false);
    }

    public void SetInput()
    {
        mainCanvas.SetActive(false);
        playCanvas.SetActive(true);
        view.gameObject.SetActive(false);
        weapownScroll.gameObject.SetActive(true);
        shiledScroll.gameObject.SetActive(true);
        Input.gameObject.SetActive(true);
        InputButton.gameObject.SetActive(true);
    }

    public void SetTest()
    {
        mainCanvas.SetActive(false);
        InputText.SetActive(false);
        playCanvas.SetActive(true);
        setTestPanel.SetActive(true);
        view.gameObject.SetActive(false);
        weapownScroll.gameObject.SetActive(false);
        shiledScroll.gameObject.SetActive(false);
        Input.gameObject.SetActive(false);
        InputButton.gameObject.SetActive(false);
        FindObjectOfType<GameManager>().isTestRoom = true;
    }

    public void reLoadScene()
    {
        SceneManager.LoadScene("BalanceTest");
    }
}
