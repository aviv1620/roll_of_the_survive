using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class SeedUi : MonoBehaviour
{
    public ManagerSettings managerSettings;

    public bool onlyIfPlay_Choose_Seeds = true;


    void Start()
    {
        if (!managerSettings.settingsGame.playerChooseSeeds && onlyIfPlay_Choose_Seeds)
        {
            gameObject.SetActive(false);
            return;
        }

        TMP_Text label = GetComponent<TMP_Text>();
        label.text = "seed dices: " + managerSettings.settingsGame.seedDices
            + "\nseed level: " + managerSettings.settingsGame.seedLevel
            + "\nseed animation: " + managerSettings.settingsGame.seedAnimation;
    }

   
}
