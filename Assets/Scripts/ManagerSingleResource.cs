using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


[RequireComponent(typeof(ResourceExpend))]
[RequireComponent(typeof(ResourceAnimation))]
public class ManagerSingleResource: MonoBehaviour
{
    private ResourceExpend resourceExpend;
    private ResourceAnimation resourceAnimation;   
   
    private int numToReduc = -1;

    void Start()
    {
        resourceExpend = GetComponent<ResourceExpend>();
        resourceAnimation = GetComponent<ResourceAnimation>();
    }   

    public void Roll()
    {
        numToReduc = resourceExpend.NumToReduc();
        resourceAnimation.Play(numToReduc);
    }

    public void DeActiveDice()
    {
        resourceExpend.Expend(numToReduc);
        resourceAnimation.Stop();
    }
}
