using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Counter))]
public class ResourceExpend : MonoBehaviour
{
    public string loseReason;
    public ManagerEnd managerEnd;
    public HolderRandomLevel holderRandomLevel;

    private Counter resourceCounter;

    void Start()
    {
        resourceCounter = GetComponent<Counter>();
    }

    public int NumToReduc()
    {
        System.Random myRandom = holderRandomLevel.MyRandom;
        int numToReduc = myRandom.Next(6);
        numToReduc++;
        return numToReduc;
    }


    public void Expend(int numToReduc)
    {
        resourceCounter.Subtract(numToReduc);

        bool lose = resourceCounter.value < 0;

        if (lose)
            managerEnd.End(loseReason);
       
    }
}
