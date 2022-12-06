using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeController : MonoBehaviour
{
    public int waitWork;
    public float curTime;
    public float coolTime = 10f;

    public bool forgeWorking = false;

    public GameObject CoinPrefab;

    public GameManager gameManager;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (forgeWorking)
        {
            if (waitWork > 0)
            {
                curTime += Time.deltaTime;
                if (curTime >= coolTime)
                {
                    Instantiate(CoinPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f), transform.rotation);
                    waitWork--;
                    curTime = 0;
                }
            }
            else
            {
                forgeWorking = false;
            }
        }
    }
}
