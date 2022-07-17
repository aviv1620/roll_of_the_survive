using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DiceAnim : MonoBehaviour
{
    public Sprite []sprites;
    public float timeBetweenFrame = 0.2f;
    private int seed;
    private Image image;
    private System.Random myRandom;

    private List<int> cardPack;

    private void OnEnable()
    {
        seed = SettingsManager.Seed_Animation;
        image = GetComponent<Image>();
        myRandom = new System.Random(seed);
        loadCard();
        StartCoroutine(WaitAndReplace());

    }

    public void setFrame(int frame)
    {
        image.sprite = sprites[frame];
    }


    private IEnumerator WaitAndReplace()
    {
        while (enabled)
        {
            int card = myRandom.Next(cardPack.Count);
            int index = cardPack[card];
            cardPack.RemoveAt(card);
            if (cardPack.Count == 0)
                loadCard();


            image.sprite = sprites[index];
            yield return new WaitForSeconds(timeBetweenFrame);
        }      
    }

    private void loadCard()
    {
        cardPack = new List<int>();
        for (int i=0;i< sprites.Length; i++)
        {
            cardPack.Add(i);
        }
    }


}
