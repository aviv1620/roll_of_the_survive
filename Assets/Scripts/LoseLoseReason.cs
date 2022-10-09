using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



[RequireComponent(typeof(TMP_Text))]
public class LoseLoseReason : MonoBehaviour
{
    public Counter dayes;

    public string foodReason;
    public string woodReason;
    public string waterReason;     

    private void LoadReason(string template)
    {        
        SaveHighScore(dayes.value);
        string str = string.Format(template, dayes.value); ;
        TMP_Text label = GetComponent<TMP_Text>();
        label.text = str;
    }

    private void SaveHighScore(int value)//FIXME not my responsibility
    {
        int m_Score = PlayerPrefs.GetInt("score", 0);
        PlayerPrefs.SetInt("score", Mathf.Max(value, m_Score));

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
