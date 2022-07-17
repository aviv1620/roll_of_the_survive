using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



[RequireComponent(typeof(TMP_Text))]
public class LoseReason : MonoBehaviour
{
    public Counter dayes;

    public string foodReason;
    public string woodReason;
    public string waterReason;
    

   private void LoadReason(string template)
    {
        string str = string.Format(template, dayes.value); ;
        TMP_Text label = GetComponent<TMP_Text>();
        label.text = str;
    }

    public void Food()
    {
        LoadReason(foodReason);
    }

    public void Wood()
    {
        LoadReason(woodReason);
    }

    public void Water()
    {
        LoadReason(waterReason);
    }
}
