using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int oreCount;
    public int ingotCount;
    public int coinCount;
    public float curTime;
    public float coolTime;
    public float mouseScroll;

    public bool menuScreenActive = false;
    public bool landPurchaseActive = false;
    public bool forgeScreenActive = false;

    public GameObject menuScreen;
    public GameObject landPurchaseScreen;
    public GameObject forgeScreen;

    public Camera mainCamera;

    public Text ingotText;
    public Text coinText;

    void Start()
    {
        menuScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        //ingotText.text = "Ingot : " + ingotCount.ToString();
        //coinText.text = "Coin : " + coinCount.ToString();
        ingotText.text = ingotCount.ToString();
        coinText.text = coinCount.ToString();

        mouseScroll = -Input.GetAxis("Mouse ScrollWheel");

        if (mainCamera.fieldOfView < 25f && mouseScroll < 0)
        {
            mainCamera.fieldOfView = 25f;
        }
        else if (mainCamera.fieldOfView >60f && mouseScroll > 0)
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
            else
            {
                if (menuScreenActive)
                {
                    menuScreen.gameObject.SetActive(false);
                    menuScreenActive = false;
                }
                else
                {
                    menuScreen.gameObject.SetActive(true);
                    menuScreenActive = true;
                }
            }
        }
    }
}
