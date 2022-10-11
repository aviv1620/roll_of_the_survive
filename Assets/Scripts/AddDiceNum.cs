using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class AddDiceNum : MonoBehaviour
{
    public ManagerSettings managerSettings;

    public HolderRandomLevel gameManager;
    public TMP_Text label;


    private int _num = -1;
    public int Num { get => _num; }

    private void OnEnable()
    {
        System.Random myRandom = gameManager.MyRandom;
        _num = myRandom.Next(managerSettings.settingsGame.costDice);
        _num++;        
        label.text = "-" + _num;
    }
}
