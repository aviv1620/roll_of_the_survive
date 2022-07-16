using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resource : Counter
{
    public Transform cointConteiner;
    public GameObject cointPref;

    protected override void updateValue()
    {
        count.text = value.ToString();

        //destory all coints
        foreach (Transform child in cointConteiner)
        {
            GameObject.Destroy(child.gameObject);
        }

        //make new coints
        for (int i=0;i< value;i++)
            Instantiate(cointPref, cointConteiner);

    }
}
