using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class ManagerDays : MonoBehaviour
{
    protected virtual void Start()
    {
        StartCoroutine(ScriptDayFirst());       
    }

    protected abstract IEnumerator ScriptDayFirst();



    public void NextDay()
    {
        StartCoroutine(ScriptDayNext());
    }

    protected abstract IEnumerator ScriptDayNext();
}
