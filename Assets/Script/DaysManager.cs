using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SlotsManager))]
public class DaysManager : MonoBehaviour
{

    private SlotsManager slotsManager;

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

    // Start is called before the first frame update
    void Start()
    {
        slotsManager = GetComponent<SlotsManager>();
        StartCoroutine(WaitTwoFrame());        
    }

    private IEnumerator WaitTwoFrame()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        firstDay();
    }

    private void firstDay()
    {
        slotsManager.Roll();
        slotsManager.Roll();
        slotsManager.Roll();

        diceFood.Roll();
        diceWood.Roll();
        diceWater.Roll();
    }

    public void nextDay()
    {
        StartCoroutine(moveDay());
    }

    private IEnumerator moveDay()
    {
        onNight.Invoke();
        slotsManager.UnRoll();
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
        daysCounter.Add(1);
        if(daysCounter.value == SettingsManager.Days_To_Recue)
            onWin.Invoke();

        onDay.Invoke();
    }





}
