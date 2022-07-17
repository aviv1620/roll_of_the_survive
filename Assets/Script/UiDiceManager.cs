using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiDiceManager : MonoBehaviour
{
    public GameObject UiDice;

    public Transform selectedSlot;
    public Transform unSelectedSlot;

    public void ShowUi()
    {
        Debug.Log("SetParent(selectedSlot");
        transform.SetParent(selectedSlot);
        UiDice.SetActive(true);
    }

    public void HideUi()
    {
        StartCoroutine(DeActiveUi());
    }

    private IEnumerator DeActiveUi()
    {        
        yield return new WaitForEndOfFrame();        
        yield return new WaitForEndOfFrame();
        UiDice.SetActive(false);
        Debug.Log("SetParent(unSelectedSlot");
        transform.SetParent(unSelectedSlot);
    }
}
