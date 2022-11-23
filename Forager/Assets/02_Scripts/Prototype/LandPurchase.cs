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

    public void LandBuy()
    {
        buttonText = EventSystem.current.currentSelectedGameObject;
        ground = GameObject.Find("Ground (" + buttonText.name + ")").gameObject;
        sea = GameObject.Find("Sea (" + buttonText.name + ")");
        
        ground.transform.position = sea.transform.position;
        sea.gameObject.SetActive(false);
    }
}
