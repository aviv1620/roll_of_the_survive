using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DiceAnimation : MonoBehaviour
{
    public Sprite []sprites;
    public float timeBetweenFrame = 0.2f;
    private int seed;
    private Image image;
    private System.Random myRandom;

    //Random the indexs of sprites like card pack.
    //The same index not Repeat when I pull.
    private List<int> indexsPack;

    private void OnEnable()
    {
        seed = ManagerSettings.Seed_Animation;
        image = GetComponent<Image>();
        myRandom = new System.Random(seed);
        LoadCard();
        StartCoroutine(ReplaceSpriteEveryTime());

    }

    public void setFrame(int frame)//FIXME Resource call it
    {
        image.sprite = sprites[frame];
    }


    private IEnumerator ReplaceSpriteEveryTime()
    {
        while (enabled)
        {
            int index = PullIndex();
            image.sprite = sprites[index];
            yield return new WaitForSeconds(timeBetweenFrame);
        }      
    }

    private int PullIndex()
    {
        int card = myRandom.Next(indexsPack.Count);
        int index = indexsPack[card];
        indexsPack.RemoveAt(card);

        if (indexsPack.Count == 0)
            LoadCard();

        return index;
    }

    private void LoadCard()
    {
        indexsPack = new List<int>();
        for (int i=0;i< sprites.Length; i++)
        {
            indexsPack.Add(i);
        }
    }


}
