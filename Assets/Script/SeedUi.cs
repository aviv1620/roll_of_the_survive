using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class SeedUi : MonoBehaviour
{

    public bool onlyIfPlay_Choose_Seeds = true;


    void Start()
    {
        if (!SettingsManager.Play_Choose_Seeds && onlyIfPlay_Choose_Seeds)
        {
            gameObject.SetActive(false);
            return;
        }

        TMP_Text label = GetComponent<TMP_Text>();
        label.text = "seed dices: " + SettingsManager.Seed_Dices 
            + "\nseed level: " + SettingsManager.Seed_Level 
            + "\nseed animation: " + SettingsManager.Seed_Animation;
    }

   
}
