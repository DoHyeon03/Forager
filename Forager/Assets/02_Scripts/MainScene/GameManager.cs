using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int ingotCount;
    public int coinCount;
    public int stoneCount;
    public float mouseScroll;

    public bool forgeScreenActive = false;

    public GameObject forgeScreen;
    public GameObject settingScreen;

    public Camera mainCamera;

    public Text ingotText;
    public Text coinText;
    public Text stoneText;

    void Update()
    {
        ingotText.text = ingotCount.ToString();
        coinText.text = coinCount.ToString();
        stoneText.text = stoneCount.ToString();

        mouseScroll = -Input.GetAxis("Mouse ScrollWheel");

        if (mainCamera.fieldOfView < 25f && mouseScroll < 0)
        {
            mainCamera.fieldOfView = 25f;
        }
        else if (mainCamera.fieldOfView > 60f && mouseScroll > 0)
        {
            mainCamera.fieldOfView = 60f;
        }
        else
        {
            mainCamera.fieldOfView += mouseScroll * 300f * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (forgeScreenActive)
            {
                forgeScreenActive = false;
                forgeScreen.SetActive(false);
            }
        }
    }

    public void SettingScreenOn()
    {
        settingScreen.SetActive(true);
    }

    public void SettingScreenOff()
    {
        settingScreen.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void GameStart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
