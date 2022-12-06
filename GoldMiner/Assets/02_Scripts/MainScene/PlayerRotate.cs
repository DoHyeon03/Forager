using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float speed;
    private RaycastHit hit;
    private int layerMask;

    public GameManager gameManager;
    public MaterialController material;
    public ForgeManager forgeManager;
    public PlayerController playerController;
    public AudioSource audiosource;

    public AudioClip attackSound1;
    public AudioClip attackSound2;
    public AudioClip attackSound3;

    private void Start()
    {
        layerMask = 1 << 6;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        forgeManager = GameObject.Find("ForgeManager").GetComponent<ForgeManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        audiosource = gameObject.GetComponent<AudioSource>();
        audiosource.clip = attackSound1;
    }

    void Update()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (GroupPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointTolook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));
        }


        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, layerMask))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (playerController.delay)
                {
                    playerController.attackOn = true;
                    if (hit.collider.CompareTag("Material"))
                    {
                        material = GameObject.Find(hit.collider.gameObject.name).GetComponent<MaterialController>();
                        material.oreHp--;
                        playerController.delay = false;
                        switch (Random.Range(1, 3))
                        {
                            case 1:
                                audiosource.clip = attackSound1;
                                break;
                            case 2:
                                audiosource.clip = attackSound2;
                                break;
                            case 3:
                                audiosource.clip = attackSound3;
                                break;
                        }
                        audiosource.Play();
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.CompareTag("Forge"))
                {
                    gameManager.forgeScreen.SetActive(true);
                    gameManager.forgeScreenActive = true;
                    forgeManager.forgePrefab = GameObject.Find(hit.collider.gameObject.name).gameObject;
                }
            }
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 2f, Color.red);
        }
    }
}
