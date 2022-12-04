using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroGameManager : MonoBehaviour
{
    public Light light;

    public void Start()
    {
        DontDestroyOnLoad(light.gameObject);
    }
    public void GameStart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
