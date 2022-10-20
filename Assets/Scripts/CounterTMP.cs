using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Counter))]
public class CounterTMP : MonoBehaviour
{
    private void Start()
    {
        Counter counter = GetComponent<Counter>();
        counter.Listen(UpdateValue);
    }

    public TMP_Text textTMP;

    private void UpdateValue(int value)
    {
        textTMP.text = value.ToString();
    }
}
