using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float speed;

    private RaycastHit hit;
    private int layerMask;

    public Ore ore;

    private void Start()
    {
        layerMask = 1 << 6;
    }
    void Update()
    {
        transform.Rotate(0f, -Input.GetAxis("Mouse X") * speed, 0f, Space.World);


        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ore = GameObject.Find(hit.collider.gameObject.name).GetComponent<Ore>();
                ore.oreHp--;
            }
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 1000f, Color.red);
        }
    }
}
