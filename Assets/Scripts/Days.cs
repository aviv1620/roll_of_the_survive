using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Counter))]
public class Days : MonoBehaviour
{
    public ManagerSettings managerSettings;

    public Transform dayConteiner;
    public GameObject dayPref;
    public GameObject dayPassPref;

    void Start()
    {
        Counter counter = GetComponent<Counter>();
        counter.Listen(UpdateValue);
    }

    private void UpdateValue(int value)
    {        

        int recue = managerSettings.settingsGame.daysToRecue;    

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
