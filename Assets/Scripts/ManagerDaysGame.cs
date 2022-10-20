using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ManagerSlots))]
[RequireComponent(typeof(ManagerSettings))]

public class ManagerDaysGame : ManagerDays
{
    public AddDiceRoll addDiceFood;
    public AddDiceRoll addDiceWood;
    public AddDiceRoll addDiceWater;

    public ManagerSingleResource resFood;
    public ManagerSingleResource resWood;
    public ManagerSingleResource resWater;

    public UnityEvent onWin;   

    public Counter daysCounter;

    public GameObject darkness;
    public GameObject popupCanvas;
    public GameObject popupWindowWin;

    protected override IEnumerator ScriptDayFirst()
    {
        //initialize 
        ManagerSlots slotsManager = GetComponent<ManagerSlots>();

        //add three dices
        slotsManager.RollNewDice();
        slotsManager.RollNewDice();
        slotsManager.RollNewDice();

        //calculate the price to add dices.
        addDiceFood.Roll();
        addDiceWood.Roll();
        addDiceWater.Roll();

        //in this situation we not wait.
        yield return new WaitForEndOfFrame();
    }

    protected override IEnumerator ScriptDayNext()
    {
        //make darkness
        darkness.SetActive(true);

        //clear occupied slots
        ManagerSlots slotsManager = GetComponent<ManagerSlots>();
        slotsManager.ClearOccupied();

        //reduc resource
        resFood.Reduc();
        resWood.Reduc();
        resWater.Reduc();

        //calculate the price to add dices.
        addDiceFood.Roll();
        addDiceWood.Roll();
        addDiceWater.Roll();

        //ReRoll all the dices
        slotsManager.ReRoll();

        //Wait one second to next day
        yield return new WaitForSeconds(1f);

        //Expend resource
        resFood.Expend();
        resWood.Expend();
        resWater.Expend();

        //disable darkness
        darkness.SetActive(false);

        //check if the player win and show popup.
        ManagerSettings managerSettings = GetComponent<ManagerSettings>();

        //
        daysCounter.Add(1);
        if (daysCounter.value == managerSettings.settingsGame.daysToRecue)
        {
            popupCanvas.SetActive(true);
            popupWindowWin.SetActive(true);
        }          


    }
}
