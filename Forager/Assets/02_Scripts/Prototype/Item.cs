using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public GameManager gameManager;

    public Text ingotCount;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ingotCount = GameObject.Find("IngotCount").GetComponent<Text>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.ingotCount++;
            ingotCount.text = $"IngotCount : {gameManager.ingotCount}";
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
