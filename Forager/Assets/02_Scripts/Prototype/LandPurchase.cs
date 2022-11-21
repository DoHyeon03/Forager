using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandPurchase : MonoBehaviour
{
    public Text buttonText;
    public GameObject ground;
    public GameObject Sea;

    public void LandBuy()
    {
        buttonText = GetComponentInChildren<Text>();
        ground = GameObject.Find("Ground (" + buttonText + ")").GetComponent<GameObject>();

    }
}
