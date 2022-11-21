using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int oreCount;
    public int ingotCount;
    public bool menuScreenActive = false;

    public Image menuScreen;

    void Start()
    {
        menuScreen.gameObject.SetActive(false);
        //menuScreen = GameObject.Find("MenuScreen").GetComponent<MenuScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
