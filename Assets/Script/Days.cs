using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Days : Counter
{
    public Transform dayConteiner;
    public GameObject dayPref;
    public GameObject dayPassPref;

    protected override void updateValue()
    {
        int recue = SettingsManager.Days_To_Recue;

        count.text = value.ToString();

        //destory all coints
        foreach (Transform child in dayConteiner)
        {
            GameObject.Destroy(child.gameObject);
        }

        //make new coints
        for (int i = 0; i < Mathf.Max(value, recue); i++)
        {
            if(i < value)
                Instantiate(dayPassPref, dayConteiner);
            else
                Instantiate(dayPref, dayConteiner);
        }
            

    }
}
