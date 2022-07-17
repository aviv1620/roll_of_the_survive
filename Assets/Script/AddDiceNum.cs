using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class AddDiceNum : MonoBehaviour
{
    public ManagerDiceLevel managerDiceLevel;
    public TMP_Text label;


    private int _num = -1;
    public int num { get => _num; }

    private void OnEnable()
    {
        System.Random myRandom = managerDiceLevel.myRandom;
        _num = myRandom.Next(SettingsManager.Cost_Dice);
        _num++;        
        label.text = "-" + _num;
    }
}
