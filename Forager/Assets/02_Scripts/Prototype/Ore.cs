using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    public int oreHp;
    public GameObject oreItem;

    void Start()
    {
        
    }

    void Update()
    {
        if (oreHp <= 0)
        {
            OreDestroy();
        }
    }

    public void OreDestroy()
    {
        Destroy(gameObject);
        Instantiate(oreItem, transform.position, transform.rotation);
    }
}
