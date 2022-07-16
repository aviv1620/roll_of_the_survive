using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Counter : MonoBehaviour
{
    public int value = 6;

    public TMP_Text count;    


    private void Start()
    {
        updateValue();
    }

    //true if resource not runs out.
    public bool Remove(int value)
    {
        Add(-1 * value);
        return this.value >= 0;
    }

    public void Add(int value)
    {
        this.value += value;
        updateValue();
    }


    protected abstract void updateValue();
}
