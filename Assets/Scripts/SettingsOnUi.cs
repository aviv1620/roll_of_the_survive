using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class SettingsOnUi : MonoBehaviour
{
    public ManagerSettings managerSettings;

    void Start()
    {
        TMP_Text label = GetComponent<TMP_Text>();
        label.text = string.Format(label.text, managerSettings.settingsGame.costDice, managerSettings.settingsGame.daysToRecue);
    }
   
}
