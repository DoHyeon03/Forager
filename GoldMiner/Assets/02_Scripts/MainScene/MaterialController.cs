using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    public int oreHp;
    public GameObject goldIngot;
    public GameObject stone;

    public GameObject itemDropSound;

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
        Instantiate(goldIngot, transform.position, transform.rotation);
        for (int i = 0; i < Random.Range(1, 3); i++)
        {
            Instantiate(stone, transform.position, transform.rotation);
            Instantiate(itemDropSound);
        }
    }
}
