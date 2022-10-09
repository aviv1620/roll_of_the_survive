using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AddDiceNumBuy))]
public class AddDiceRoll : MonoBehaviour
{

    public float timeAnimation = 1f;
    public GameObject anim;
    public GameObject dice;

    public void Roll()
    {
        StartCoroutine(Play());
    }


    private IEnumerator Play()
    {
        AddDiceNumBuy buyDice = GetComponent<AddDiceNumBuy>();
        anim.SetActive(true);
        dice.SetActive(false);
        buyDice.UpdateInteractable();

        yield return new WaitForSeconds(timeAnimation);   
        
        anim.SetActive(false);
        dice.SetActive(true);      
        buyDice.UpdateInteractable();
    }

    public void UnRoll()
    {
        anim.SetActive(false);
        dice.SetActive(false);
        AddDiceNumBuy buyDice = GetComponent<AddDiceNumBuy>();
        buyDice.UpdateInteractable();
    }
}
