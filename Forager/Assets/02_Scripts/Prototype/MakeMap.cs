using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MakeMap : MonoBehaviour
{
    public int mapSize;
    public float mapSizeHalf;

    public GameObject groundPrefab;

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
                ground.name = "GroundPrefab(" + count + ")";
                count++;
            }
        }
    }
}
