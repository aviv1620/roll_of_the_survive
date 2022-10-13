using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SlotSwitch))]
public class ManagerSingleSlot : MonoBehaviour
{

    private SlotSwitch slotSwitch;

    public float timeAnim = 1f;

    private void Start()
    {
        slotSwitch = GetComponent<SlotSwitch>();
    }

    public void ReRoll()
    {
        bool canReRoll = slotSwitch.dice.activeSelf;
        if (canReRoll)
            RollNewDice();
    }

    public void RollNewDice()
    {
        slotSwitch.SwitchTo(SlotMode.anim);
        StartCoroutine(RollDice());
    }

    private IEnumerator RollDice()
    {
        yield return new WaitForSeconds(timeAnim);
        slotSwitch.SwitchTo(SlotMode.dice);
    }

    public void Occupied()
    {
        slotSwitch.SwitchTo(SlotMode.occupied);
    }

    public void ClearOccupied()
    {
        bool itOccupied = slotSwitch.occupied.activeSelf;
        if (itOccupied)
            slotSwitch.SwitchTo(SlotMode.empty);
    }
}

