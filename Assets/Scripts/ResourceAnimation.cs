using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceAnimation : MonoBehaviour
{
    public GameObject dice;  
    public MsgTemporary msgTemporary;
    public float time = 0.5f;

    private DiceAnimation diceAnimation;

    void Start()
    {
        diceAnimation = dice.GetComponent<DiceAnimation>();
    }

   public void Play(int numToReduc)
    {
        StartCoroutine(PlayCoroutine(numToReduc));
      
    }


    private IEnumerator PlayCoroutine(int numToReduc)
    {
        dice.SetActive(true);
        diceAnimation.enabled = true;

        yield return new WaitForSeconds(time);

        diceAnimation.SetFrame(numToReduc - 1);
        msgTemporary.Play("-" + numToReduc);
        diceAnimation.enabled = false;
    }

    public void Stop()
    {
        dice.SetActive(false);
    }
}
