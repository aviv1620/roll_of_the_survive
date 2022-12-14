using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class DiceNum : MonoBehaviour
{
    public ManagerSettings managerSettings;

    private static System.Random myRandom;
    public Sprite[] sprites;
    private int _num;

    public int Num { get => _num; }

    

    private void OnEnable()
    {
        //roll
        if (myRandom == null)
            myRandom = new System.Random(managerSettings.settingsGame.seedDices);

        int index = myRandom.Next(sprites.Length);

        Image image = GetComponent<Image>();
        image.sprite = sprites[index];

        _num = index + 1;

    }



}
