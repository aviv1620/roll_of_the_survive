using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BuyDice : MonoBehaviour
{
    public Resource resource;
    public AddDiceNum addDiceNum;
    public SlotsManager slotsManager;

    private Button button;

    public UnityEvent buy;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Buy);
        updateInteractable();
        slotsManager.onChange.AddListener(updateInteractable);
        resource.onChange.AddListener(updateInteractable);
    }

    private void OnEnable()
    {
        if(button != null)
            updateInteractable();
    }

    public void Buy()
    {
        if (!ValidBuy())
        {
            updateInteractable();
            return;
        }

        buy.Invoke();

        int num = addDiceNum.num;
        resource.Remove(num);
        slotsManager.Roll();



    }

    public void updateInteractable()
    {
        button.interactable = ValidBuy();
    }

    private bool ValidBuy()
    {        
        return slotsManager.HaveEmptySlot() && resource.value >= addDiceNum.num && addDiceNum.gameObject.activeSelf;
    }
}
