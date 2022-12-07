using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public Slider musicSlider;
    public AudioSource audioSource;

    void Update()
    {
        audioSource.volume = musicSlider.value;
    }
}
