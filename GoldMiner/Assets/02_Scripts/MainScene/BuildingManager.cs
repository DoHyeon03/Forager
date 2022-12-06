using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public bool buildingButtonOn;

    public GameObject forgePrefab;
    public GameManager gameManager;

    public AudioSource audioSource;

    public Button buildingOn;
    public Button buildingOff;

    public RaycastHit hit;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (buildingButtonOn)
        {
            buildingOn.gameObject.SetActive(true);
            buildingOff.gameObject.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        switch (hit.collider.tag)
                        {
                            case "Ground":
                                if (gameManager.stoneCount >= 10)
                                {
                                    GameObject forge = Instantiate(forgePrefab);
                                    forge.transform.position = hit.collider.transform.position + new Vector3(0.5f, hit.collider.transform.localScale.y + 0.5f, -0.5f);
                                    gameManager.stoneCount -= 10;
                                }
                                buildingButtonOn = false;
                                audioSource.Play();
                                break;
                            case "Forge":
                                Debug.Log("건설 불가");
                                break;
                        }
                    }
                }
            }
        }
        else
        {
            buildingOn.gameObject.SetActive(false);
            buildingOff.gameObject.SetActive(true);
        }
    }

    public void BuildOn()
    {
        buildingButtonOn = true;
    }

    public void BuildOff()
    {
        buildingButtonOn = false;
    }
}
