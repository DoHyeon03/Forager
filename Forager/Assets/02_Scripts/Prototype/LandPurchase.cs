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
    public GameObject groundPrefab;
    public GameObject oreMakerPrefab;

    public Button buttonPrefab;

    public GameManager gameManager;
    public OreMaker oreMaker;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void LandBuy()
    {
        if (gameManager.coinCount >= 100)
        {
            buttonText = EventSystem.current.currentSelectedGameObject;
            groundPrefab = GameObject.Find("GroundPrefab(" + buttonText.name + ")");
            ground = groundPrefab.transform.GetChild(0).gameObject;
            sea = groundPrefab.transform.GetChild(1).gameObject;
            oreMaker = groundPrefab.transform.Find("OreMaker").GetComponent<OreMaker>();

            ground.transform.position = sea.transform.position;
            sea.gameObject.SetActive(false);
            oreMaker.landVisible = true;
            buttonText.SetActive(false);
            gameManager.coinCount -= 100;
        }
        else
        {
            Debug.Log("땅을 살수 없습니다");
        }
    }
}
