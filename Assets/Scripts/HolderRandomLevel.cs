using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(ManagerSettings))]
public class HolderRandomLevel : MonoBehaviour
{   
    private System.Random _myRandom;

    public System.Random MyRandom { get => _myRandom; }

    private void Start()
    {
        ManagerSettings managerSettings = GetComponent<ManagerSettings>();
        _myRandom = new System.Random(managerSettings.settingsGame.seedLevel);
    }
}
