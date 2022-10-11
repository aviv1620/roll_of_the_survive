using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Counter : MonoBehaviour
{
    public int value = 6;

    [HideInInspector]
    public UnityEvent<int> EventChange;

    private void Start()
    {
        UpdateValue();
    }
    
    public void Subtract(int value)
    {
        Add(-1 * value);      
    }

    public void Add(int value)
    {
        this.value += value;
        UpdateValue();
    }

    public void Listen(UnityAction<int> call)
    {
        EventChange.AddListener(call);
        EventChange.Invoke(value);
    }


    private void UpdateValue()
    {       
        EventChange.Invoke(value);
    }
}
