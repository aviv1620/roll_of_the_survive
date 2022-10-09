using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Counter : MonoBehaviour
{
    public int value = 6;
    
    private void Start()
    {
        updateValue();
    }
    
    public void Remove(int value)
    {
        Add(-1 * value);      
    }

    public void Add(int value)
    {
        this.value += value;
        updateValue();
    }


    protected abstract void updateValue();
}
