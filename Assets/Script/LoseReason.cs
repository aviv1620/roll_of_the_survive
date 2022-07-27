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
  
    private void highestDays(int value)
    {
        int m_Score = PlayerPrefs.GetInt("score", 0);
        PlayerPrefs.SetInt("score", Mathf.Max(value, m_Score));

    }

    private void LoadReason(string template)
    {
        //
        highestDays(dayes.value);
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
