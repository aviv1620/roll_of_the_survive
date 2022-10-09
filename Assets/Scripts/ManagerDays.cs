using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ManagerSlots))]
public class ManagerDays : MonoBehaviour
{

    private ManagerSlots slotsManager;

    public AddDiceRoll diceFood;
    public AddDiceRoll diceWood;
    public AddDiceRoll diceWater;

    public Resource resFood;
    public Resource resWood;
    public Resource resWater;

    public UnityEvent onNight;
    public UnityEvent onDay;
    public UnityEvent onWin;

    public Days daysCounter;

  
    void Start()
    {
        slotsManager = GetComponent<ManagerSlots>();
        FirstDay();
    }    

    private void FirstDay()
    {
        slotsManager.RollNewDice();
        slotsManager.RollNewDice();
        slotsManager.RollNewDice();

        diceFood.Roll();
        diceWood.Roll();
        diceWater.Roll();
    }

    public void NextDay()
    {
        StartCoroutine(MoveDay());
    }

    private IEnumerator MoveDay()
    {        
        onNight.Invoke();

        slotsManager.ClearOccupied();

        resFood.Roll();
        resWood.Roll();
        resWater.Roll();

        diceFood.Roll();
        diceWood.Roll();
        diceWater.Roll();

        slotsManager.ReRoll();

        yield return new WaitForSeconds(1f);

        resFood.DeActiveDice();
        resWood.DeActiveDice();
        resWater.DeActiveDice();

        onDay.Invoke();

        daysCounter.Add(1);
        if(daysCounter.value == ManagerSettings.Days_To_Recue)
            onWin.Invoke();

        
    }





}
