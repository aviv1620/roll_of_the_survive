using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class highestDaysUi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int m_Score = PlayerPrefs.GetInt("score", 0);
        TMP_Text label = GetComponent<TMP_Text>();
        label.text = string.Format(label.text, m_Score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
