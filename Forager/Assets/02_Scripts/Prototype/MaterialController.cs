using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    public int oreHp;
    public GameObject oreItem;

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
