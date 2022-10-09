using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Resource : CounterTMP
{
    public Transform cointConteiner;
    public GameObject cointPref;

    [HideInInspector]
    public UnityEvent onChange;

    public UnityEvent onLose;

    public GameObject Dice;
    public float timeRoll = 0.5f;
    public HolderRandomLevel managerDiceLevel;
    public MsgTemporary msgTemporary;
    private int numToReduc = -1;

    protected override void updateValue()
    {
        base.updateValue();

        //destory all coints
        foreach (Transform child in cointConteiner)
        {
            GameObject.Destroy(child.gameObject);
        }

        //make new coints
        for (int i=0;i< value;i++)
            Instantiate(cointPref, cointConteiner);

        onChange.Invoke();
    }

    public void Lose()
    {
        onLose.Invoke();
    }

    public void Roll()
    {
        StartCoroutine(WaitEndRoll());
    }

    private IEnumerator WaitEndRoll()
    {
        DiceAnimation diceAnim = Dice.GetComponent<DiceAnimation>();

        Dice.SetActive(true);
        diceAnim.enabled = true;
        yield return new WaitForSeconds(timeRoll);
        
        System.Random myRandom = managerDiceLevel.MyRandom;
        numToReduc = myRandom.Next(6);
        diceAnim.setFrame(numToReduc);
        numToReduc++;
        msgTemporary.Play("-" + numToReduc);
        //Debug.Log("numToReduc "+ numToReduc);

        diceAnim.enabled = false;
    }

    public void DeActiveDice()
    {
        Remove(numToReduc);

        bool lose = value < 0;

        if (lose)
            Lose();

        Dice.SetActive(false);
    }
}
