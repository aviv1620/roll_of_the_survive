using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

[RequireComponent(typeof(Image))]
public class DiceNum : MonoBehaviour
{
    public ManagerSettings managerSettings;

    private static Random random;
    public Sprite[] dieFacesImages;
    private int dieValue;

    public int DieValue { get => dieValue; }

    private void OnEnable()
    {
        RandomizeDieValue();
    }

    private void RandomizeDieValue()
    {
        if (random == null)
        {
            random = new Random(managerSettings.settingsGame.seedDices);
        }

        int index = random.Next(dieFacesImages.Length);

        Image image = GetComponent<Image>();
        image.sprite = dieFacesImages[index];

        dieValue = index + 1;
    }
}
