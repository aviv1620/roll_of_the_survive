using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = System.Random;

[RequireComponent(typeof(ManagerSettings))]
public class HolderRandomLevel : MonoBehaviour
{
    public Random MyRandom { get; private set; }

    private void Start()
    {
        ManagerSettings managerSettings = GetComponent<ManagerSettings>();
        MyRandom = new Random(managerSettings.settingsGame.seedLevel);
    }
}
