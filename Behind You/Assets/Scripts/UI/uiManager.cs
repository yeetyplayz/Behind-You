using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class uiManager : MonoBehaviour
{
    public GameObject[] uiObjects;
    private bool isPaused = false;

    private void Start()
    {
        EnableUi(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause(1);
            }
            else
            {
                Pause(2);
            }
        }
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
    private void Pause(int i)
    {
        if (i == 1)
        {
            isPaused = true;
            EnableUi(5);
            Time.timeScale = 0f;
        }
        else if (i == 2)
        {
            isPaused = false;
            DisableUi();
            Time.timeScale = 1f;
        }
    }
}
