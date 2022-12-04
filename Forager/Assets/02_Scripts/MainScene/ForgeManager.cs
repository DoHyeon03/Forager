using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeManager : MonoBehaviour
{
    public GameObject forgePrefab;

    public ForgeController forgeContoller;
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();  
    }


    public void ForgeStart()
    {
        gameManager.ingotCount--;
        forgeContoller = forgePrefab.GetComponent<ForgeController>();
        forgeContoller.waitWork++;
        forgeContoller.forgeWorking = true;
    }

}
