using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreMaker : MonoBehaviour
{
    public GameObject ore;
    public float curtime;
    public float cooltime;

    public RaycastHit hit;
    public RaycastHit hit2;

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
                int randomX = Random.Range(-6, 6);
                int randomZ = Random.Range(-6, 6);
                if (Physics.Raycast(new Vector3(transform.position.x + randomX + 0.5f, 0.5f, transform.position.z + randomZ + 0.5f), transform.TransformDirection(Vector3.down), out hit, 1f))
                {
                    if (hit.collider.CompareTag("Ground"))
                    {
                        if (Physics.Raycast(new Vector3(transform.position.x + randomX + 0.5f, 0.5f, transform.position.z + randomZ + 0.5f), transform.TransformDirection(Vector3.zero), out hit2, 1f))
                        {
                            if (hit2.collider.CompareTag("Ore"))
                            {
                                i--;
                                continue;
                            }
                            else
                            {
                                Instantiate(ore, new Vector3(transform.position.x + randomX + 0.5f, 0.5f, transform.position.z + randomZ + 0.5f), transform.rotation);
                                ore.name = $"Ore_{gameManager.oreCount}";
                                gameManager.oreCount++;
                            }
                        }
                    }
                    else
                    {
                        i--;
                        continue;
                    }
                }
            }
            curtime = 0;
        }
    }
}
