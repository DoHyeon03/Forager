using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int oreCount;
    public int ingotCount;
    public bool menuScreenActive = false;
    public bool landPurchaseActive = false;

    public Image menuScreen;
    public Image landPurchaseScreen;

    void Start()
    {
        menuScreen.gameObject.SetActive(false);
        //menuScreen = GameObject.Find("MenuScreen").GetComponent<MenuScreen>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuScreenActive)
            {
                menuScreen.gameObject.SetActive(false);
                menuScreenActive = false;
                if (landPurchaseActive)
                {
                    LandPurchaseMenu();
                }
            }
            else
            {
                menuScreen.gameObject.SetActive(true);
                menuScreenActive = true;
            }

        }
    }

    public void LandPurchaseMenu()
    {
        if (landPurchaseActive)
        {
            landPurchaseScreen.gameObject.SetActive(false);
            landPurchaseActive = false;
        }
        else
        {
            landPurchaseScreen.gameObject.SetActive(true);
            landPurchaseActive = true;
        }
    }
}
