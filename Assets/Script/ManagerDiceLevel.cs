using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ManagerDiceLevel : MonoBehaviour
{

    private System.Random _myRandom;

    public System.Random myRandom { get => _myRandom; }

    private void Awake()
    {
        _myRandom = new System.Random(SettingsManager.Seed_Level);
    }
}
