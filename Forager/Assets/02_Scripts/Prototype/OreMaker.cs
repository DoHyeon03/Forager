using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreMaker : MonoBehaviour
{
    public GameObject ore;
    public float curtime;
    public float cooltime;

    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        curtime += Time.deltaTime;
        if (curtime >= cooltime)
        {
            int randomOre = Random.Range(1, 5);
            for (int i = 0; i < randomOre; i++)
            {
                int randomX = Random.Range(-10, 10);
                int randomZ = Random.Range(-10, 10);
                Instantiate(ore, new Vector3(randomX, 0.5f, randomZ), transform.rotation);
                ore.name = $"Ore_{gameManager.oreCount}";
                gameManager.oreCount++;
            }

            curtime = 0;
        }
    }
}
