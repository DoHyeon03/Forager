using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundBuy : MonoBehaviour
{
    public Text buttonText;
    public GameObject ground;
    public GameObject sea;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void BuyGround()
    {
        ground.transform.position = sea.transform.position;
        sea.SetActive(false);
    }
}
