using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class EndDialogReason : MonoBehaviour
{
    public Counter dayesCounter; 

    public void LoadReason(string template)
    {
        string str = string.Format(template, dayesCounter.value);
        TMP_Text label = GetComponent<TMP_Text>();
        label.text = str;
    }
}
