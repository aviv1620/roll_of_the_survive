using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class SeedUi : MonoBehaviour
{
    
    void Start()
    {
        if (!SettingsManager.Play_Choose_Seeds)
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
