using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BuyDice))]
public class AddDiceRoll : MonoBehaviour
{

    public float TimeAnim = 1f;
    public GameObject Anim;
    public GameObject Dice;

    public void Roll()
    {
        StartCoroutine(Play());
    }


    private IEnumerator Play()
    {
        BuyDice buyDice = GetComponent<BuyDice>();
        Anim.SetActive(true);
        Dice.SetActive(false);
        buyDice.updateInteractable();
        yield return new WaitForSeconds(TimeAnim);             
        Anim.SetActive(false);
        Dice.SetActive(true);      
        buyDice.updateInteractable();
    }

    public void UnRoll()
    {
        Anim.SetActive(false);
        Dice.SetActive(false);
        BuyDice buyDice = GetComponent<BuyDice>();
        buyDice.updateInteractable();
    }
}
