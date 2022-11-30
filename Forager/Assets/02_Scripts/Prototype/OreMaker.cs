using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreMaker : MonoBehaviour
{
    public GameObject ore;
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
                Debug.Log(randomOre);
                for (int i = 0; i < randomOre; i++)
                {
                    int randomX = Random.Range(-6, 6);
                    int randomZ = Random.Range(-6, 6);

                    if (Physics.Raycast(new Vector3(transform.position.x + randomX + 0.5f, 0.5f, transform.position.z + randomZ + 0.5f), transform.TransformDirection(Vector3.down), out hit, 1f))
                    {
                        Debug.Log(hit.collider.tag);
                        if (hit.collider.CompareTag("Ground"))
                        {
                            Instantiate(ore, new Vector3(transform.position.x + randomX + 0.5f, 0.5f, transform.position.z + randomZ + 0.5f), transform.rotation);
                            ore.name = $"Ore_{gameManager.oreCount}";
                            gameManager.oreCount++;

                            //중복 생성 안되게 하는 코드
                            /*
                            if (Physics.Raycast(new Vector3(transform.position.x + randomX + 0.5f, 0.5f, transform.position.z + randomZ + 0.5f), transform.TransformDirection(Vector3.zero), out hit2, 1f))
                            {
                                Debug.Log(hit2.collider.tag);
                                if (hit2.collider.CompareTag("Material"))
                                {
                                    i--;
                                    continue;
                                }
                            }
                            else
                            {
                            }
                            */
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
}
