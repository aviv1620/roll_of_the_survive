using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

[RequireComponent(typeof(Slider))]
public class SliderAudio : MonoBehaviour
{


    public string param = "game";
    public AudioMixer mixer;

    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(volume);
    }

    private void volume(float arg0)
    {
        mixer.SetFloat(param, arg0);
    }
}
