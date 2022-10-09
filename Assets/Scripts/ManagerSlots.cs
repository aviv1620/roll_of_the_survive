using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManagerSlots : MonoBehaviour
{
    private readonly string TagEmpty = "EmptySlot";
    private readonly int NumSlots = 4;

    [HideInInspector]
    public UnityEvent onChange;

    [HideInInspector]
    public ManagerSlotSingle[] slotsManager;



    private void Awake()
    {       
        GameObject[] slots = StartFindSlots();
        StartInsertAndListenSlotsManager(slots);
       
    }

    private GameObject[] StartFindSlots()
    {
        GameObject[] slots = GameObject.FindGameObjectsWithTag(TagEmpty);

        if (slots.Length != NumSlots)
            Debug.LogError("all " + NumSlots + " slots need start the scene with empty active");

        return slots;
    }

    private void StartInsertAndListenSlotsManager(GameObject[] slots)
    {
        slotsManager = new ManagerSlotSingle[NumSlots];

        for (int i = 0; i < slots.Length; i++)
        {
            GameObject slot = slots[i];
            SlotSwitch slotSwitch = slot.GetComponentInParent<SlotSwitch>();
            slotSwitch.onChange.AddListener(onSlotChange);
            slotsManager[i] = slot.GetComponentInParent<ManagerSlotSingle>();
        }
    }


    public bool HaveEmptySlot()
    {        
        return GameObject.FindGameObjectsWithTag(TagEmpty).Length > 0;
    }

    private ManagerSlotSingle FindEmptySlot()
    {
        return GameObject.FindGameObjectWithTag(TagEmpty).GetComponentInParent<ManagerSlotSingle>();
    }

    public void RollNewDice()
    {
        if (!HaveEmptySlot())
        {
            Debug.LogWarning("not roll becasue not have Empty Slot");
            return;
        }
        
        ManagerSlotSingle emptySlot = FindEmptySlot();
        emptySlot.RollNewDice();        
    }

    public void ClearOccupied()
    {
        foreach(ManagerSlotSingle slot in slotsManager)
        {
            slot.ClearOccupied();
        }
    }

    public void ReRoll()
    {
        foreach (ManagerSlotSingle slot in slotsManager)
        {
            slot.ReRoll();
        }
    }

    private void onSlotChange()
    {
        onChange.Invoke();
    }
}
