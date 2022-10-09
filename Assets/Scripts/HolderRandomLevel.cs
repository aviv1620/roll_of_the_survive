using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class HolderRandomLevel : MonoBehaviour
{

    private System.Random _myRandom;

    public System.Random MyRandom { get => _myRandom; }

    private void Awake()
    {
        _myRandom = new System.Random(ManagerSettings.Seed_Level);
    }
}
