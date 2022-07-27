using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class SettingsOnUi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text label = GetComponent<TMP_Text>();
        label.text = string.Format(label.text, SettingsManager.Cost_Dice, SettingsManager.Days_To_Recue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
