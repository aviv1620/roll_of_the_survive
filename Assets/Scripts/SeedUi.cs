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
        if (!ManagerSettings.Play_Choose_Seeds && onlyIfPlay_Choose_Seeds)
        {
            gameObject.SetActive(false);
            return;
        }

        TMP_Text label = GetComponent<TMP_Text>();
        label.text = "seed dices: " + ManagerSettings.Seed_Dices 
            + "\nseed level: " + ManagerSettings.Seed_Level 
            + "\nseed animation: " + ManagerSettings.Seed_Animation;
    }

   
}
