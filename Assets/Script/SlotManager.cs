using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SlotSwitch))]
public class SlotManager : MonoBehaviour
{

    private SlotSwitch slotSwitch;

    public float TimeAnim = 1f;

    private void Start()
    {
        slotSwitch = GetComponent<SlotSwitch>();
    }

    public void Roll()
    {
        slotSwitch.switchTo(SlotMode.anim);
        StartCoroutine(RollDice());
    }

    private IEnumerator RollDice()
    {
        yield return new WaitForSeconds(TimeAnim);
        slotSwitch.switchTo(SlotMode.dice);
    }

    public void Occupied()
    {
        slotSwitch.switchTo(SlotMode.occupied);
    }

    public void Empty()
    {
        if(slotSwitch.occupied.activeSelf)
            slotSwitch.switchTo(SlotMode.empty);
    }
}

