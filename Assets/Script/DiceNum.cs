using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class DiceNum : MonoBehaviour
{

    private static System.Random myRandom;
    public Sprite[] sprites;
    private int _num;

    public int num { get => _num; }

    

    private void OnEnable()
    {
        if (myRandom == null)
            myRandom = new System.Random(SettingsManager.Seed_Dices);

        int index = myRandom.Next(sprites.Length);

        Image image = GetComponent<Image>();
        image.sprite = sprites[index];

        _num = index + 1;

    }



}
