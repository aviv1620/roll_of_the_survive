using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class CounterTMP : Counter
{

    public TMP_Text textTMP;

    protected override void updateValue()
    {
        textTMP.text = value.ToString();
    }
}
