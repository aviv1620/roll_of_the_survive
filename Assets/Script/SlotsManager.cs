using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlotsManager : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent onChange;

    private string tagEmpty = "EmptySlot";

    public SlotManager[] slotsMan;
    private readonly int numSlots = 4;


    private void Start()
    {
        GameObject[] slots = GameObject.FindGameObjectsWithTag(tagEmpty);
        if (slots.Length != numSlots)
            Debug.LogError("all "+ numSlots+" slots need start the scene with empty active");

        slotsMan = new SlotManager[numSlots];

        for (int i = 0; i < slots.Length;i++)
        {
            GameObject slot = slots[i];
            SlotSwitch slotSwitch = slot.GetComponentInParent<SlotSwitch>();
            slotSwitch.onChange.AddListener(slotChange);
            slotsMan[i] = slot.GetComponentInParent<SlotManager>();
        }
    }

    public bool HaveEmptySlot()
    {
        
        return GameObject.FindGameObjectsWithTag(tagEmpty).Length > 0;
    }

    public void Roll()
    {
        if (!HaveEmptySlot())
        {
            Debug.LogWarning("not roll becasue not have Empty Slot");
            return;
        }

        SlotManager slotManager = GameObject.FindGameObjectWithTag(tagEmpty).GetComponentInParent<SlotManager>();
        slotManager.Roll();        
    }

    public void UnRoll()
    {
        foreach(SlotManager slot in slotsMan)
        {
            slot.Empty();
        }
    }

    public void ReRoll()
    {
        foreach (SlotManager slot in slotsMan)
        {
            slot.ReRoll();
        }
    }

    private void slotChange()
    {
        onChange.Invoke();
    }
}
