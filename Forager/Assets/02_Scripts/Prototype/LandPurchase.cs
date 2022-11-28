using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LandPurchase : MonoBehaviour
{
    public GameObject buttonText;
    public GameObject ground;
    public GameObject sea;
    public GameObject landUI;
    public GameObject groundPrefab;

    public Button buttonPrefab;

    public MakeMap makeMap;

    void Start()
    {
        makeMap = GameObject.Find("LandManager").GetComponent<MakeMap>();

        int count = 1;

        for (int i = 0; i < makeMap.mapSize; i++)
        {
            for (int j = 0; j < makeMap.mapSize; j++)
            {
                Button button = Instantiate(buttonPrefab);
                Text buttonText = button.GetComponentInChildren<Text>();
                button.transform.SetParent(landUI.transform, false);
                button.name = count.ToString();
                buttonText.text = count.ToString();
                count++;
            }
        }
        
    }

    public void LandBuy()
    {
        buttonText = EventSystem.current.currentSelectedGameObject;
        groundPrefab = GameObject.Find("GroundPrefab(" + buttonText.name + ")");
        ground = groundPrefab.transform.Find("Ground").GetComponent<GameObject>();
        sea = groundPrefab.transform.Find("Sea").GetComponent<GameObject>();

        ground.transform.position = sea.transform.position;
        sea.gameObject.SetActive(false);
    }
}
