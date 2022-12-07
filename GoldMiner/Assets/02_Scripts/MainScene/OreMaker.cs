using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreMaker : MonoBehaviour
{
    public GameObject ore;
    public GameObject oreMakeSound;

    public float curtime;
    public float cooltime;

    public bool landVisible = false;

    public RaycastHit hit;
    public RaycastHit hit2;

    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (landVisible)
        {
            curtime += Time.deltaTime;
            if (curtime >= cooltime)
            {
                int randomOre = Random.Range(3, 5);
                for (int i = 0; i < randomOre; i++)
                {
                    int randomX = Random.Range(-6, 6);
                    int randomZ = Random.Range(-6, 6);

                    if (Physics.Raycast(new Vector3(transform.position.x + randomX + 0.5f, 0.5f, transform.position.z + randomZ + 0.5f), transform.TransformDirection(Vector3.down), out hit, 2f))
                    {
                        //Debug.Log(new Vector3(transform.position.x + randomX + 0.5f, 0.5f, transform.position.z + randomZ + 0.5f));
                        //Debug.Log(hit.collider.tag);
                        switch (hit.collider.tag)
                        {
                            case "Ground":
                                Instantiate(ore, new Vector3(transform.position.x + randomX + 0.5f, 0.5f, transform.position.z + randomZ + 0.5f), transform.rotation);
                                ore.name = $"Ore_{gameManager.oreCount}";
                                gameManager.oreCount++;
                                break;
                            case "Forge":
                                i--;
                                continue;
                                break;
                            case "Water":
                                i--;
                                continue;
                                break;
                            case "Material":
                                i--;
                                continue;
                                break;
                        }
                    }
                }
                Instantiate(oreMakeSound);
                curtime = 0;
            }
        }
    }
}
