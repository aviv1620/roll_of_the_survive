using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ManagerSlots))]
[RequireComponent(typeof(ManagerSettings))]
public class ManagerDays : MonoBehaviour
{
    private ManagerSettings managerSettings;
    private ManagerSlots slotsManager;

    public AddDiceRoll diceFood;
    public AddDiceRoll diceWood;
    public AddDiceRoll diceWater;

    public ManagerSingleResource resFood;
    public ManagerSingleResource resWood;
    public ManagerSingleResource resWater;

    public UnityEvent onNight;
    public UnityEvent onDay;
    public UnityEvent onWin;

    public Counter daysCounter;

  
    void Start()
    {
        managerSettings = GetComponent<ManagerSettings>();
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
        if(daysCounter.value == managerSettings.settingsGame.daysToRecue)
            onWin.Invoke();

        
    }





}
