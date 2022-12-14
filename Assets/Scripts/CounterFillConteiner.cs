using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Counter))]
public class CounterFillConteiner : MonoBehaviour
{
    public Transform cointConteiner;
    public GameObject cointPref;

    private void Start()
    {
        Counter counter = GetComponent<Counter>();
        counter.Listen(UpdateValue);
    }

    private void UpdateValue(int value)
    {
        //destory all coints
        foreach (Transform child in cointConteiner)
        {
            GameObject.Destroy(child.gameObject);
        }

        //make new coints
        for (int i = 0; i < value; i++)
            Instantiate(cointPref, cointConteiner);
    }
}
