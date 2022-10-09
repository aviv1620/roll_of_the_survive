using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AddDiceNumBuy : MonoBehaviour
{
    public Resource resource;
    public AddDiceNum addDiceNum;
    public ManagerSlots slotsManager;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnBuy);
        UpdateInteractable();
        slotsManager.onChange.AddListener(UpdateInteractable);
        resource.onChange.AddListener(UpdateInteractable);
    }

    private void OnEnable()
    {
        if(button != null)
            UpdateInteractable();
    }

    public void OnBuy()
    {
        if (!ValidationCanBuy())
        {
            UpdateInteractable();
            return;
        }

        int num = addDiceNum.Num;
        resource.Remove(num);
        slotsManager.RollNewDice();



    }

    public void UpdateInteractable()
    {
        button.interactable = ValidationCanBuy();
    }

    private bool ValidationCanBuy()
    {        
        return slotsManager.HaveEmptySlot() && resource.value >= addDiceNum.Num && addDiceNum.gameObject.activeSelf;
    }
}
