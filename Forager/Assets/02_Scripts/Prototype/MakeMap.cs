using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MakeMap : MonoBehaviour
{
    public int mapSize;
    public float mapSizeHalf;

    public GameObject groundPrefab;
    public Button buttonPrefab;

    void Start()
    {
        int count = 1;

        mapSizeHalf = (int)Math.Truncate((double)mapSize / 2);
        for (int i = -(int)mapSizeHalf; i <= (int)mapSizeHalf; i++)
        {
            for (int j = -(int)mapSizeHalf; j <= (int)mapSizeHalf; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }   
                GameObject ground= Instantiate(groundPrefab, new Vector3(i * 12, 0, j * 12), transform.rotation);
                Button button = Instantiate(buttonPrefab);
                Canvas canvas = ground.GetComponentInChildren<Canvas>();
                ground.name = "GroundPrefab(" + count + ")";
                button.transform.SetParent(canvas.transform, false);
                button.name = count.ToString();
                Text buttonText = button.GetComponentInChildren<Text>();
                buttonText.text = count.ToString();
                
                count++;
            }
        }
        buttonPrefab.gameObject.SetActive(false);
    }
}
