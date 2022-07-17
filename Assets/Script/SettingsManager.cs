using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static bool Play_Tutorial = true;
    public static int Cost_Dice = 3;
    public static int Days_To_Recue = 5;

    public static bool Play_Choose_Seeds = false;

    public static int Seed_Dices = 668512;
    public static int Seed_Level = 668513;
    public static int Seed_Animation = 668514;

    

    void Awake()
    {
        System.Random rnd = new System.Random();

        Seed_Dices = rnd.Next();
        Seed_Level = rnd.Next();
        Seed_Animation = rnd.Next();
        UnityEngine.Object.DontDestroyOnLoad(this.gameObject);
    }





}
