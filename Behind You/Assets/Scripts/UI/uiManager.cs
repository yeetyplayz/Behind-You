using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiManager : MonoBehaviour
{
    public GameObject[] uiObjects;
    private List<int> uiStuff = new List<int>() {  };
    private int lastUi;

    private void Start()
    {
        EnableUi(0);
    }
    public void DisableUi()
    {
        for (int i = 0; i < uiObjects.Length; i++)
        {
            uiObjects[i].SetActive(false);
        }
    }
    public void EnableUi(int ui)
    {
        DisableUi();
        uiObjects[ui].SetActive(true);
        lastUi = ui;
    }
    IEnumerator startGame2()
    {
        uiObjects[1].SetActive(false);
        new WaitForSeconds(5f);
        uiObjects[2].SetActive(false);
        yield return null;
    }
    public void Go(int i)
    {
        StartCoroutine(startGame2());
    }
}
