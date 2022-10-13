using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Counter))]
public class ResourceFloatingActionHolder : MonoBehaviour
{
    private Counter counter;

    public Image icon;

    void Start()
    {
        counter = GetComponent<Counter>();
    }

   
    public Sprite GetIcon()
    {
        return icon.sprite;
    }

    public void Add(int value)
    {
        counter.Add(value);
    }    

}
