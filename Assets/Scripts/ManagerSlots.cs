using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManagerSlots : MonoBehaviour
{
    private readonly string TagEmpty = "EmptySlot";
    public int NumSlots = 4;



    [HideInInspector]
    public UnityEvent onChange;

    [HideInInspector]
    public ManagerSingleSlot[] slotsManager;



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
        slotsManager = new ManagerSingleSlot[NumSlots];

        for (int i = 0; i < slots.Length; i++)
        {
            GameObject slot = slots[i];
            SlotSwitch slotSwitch = slot.GetComponentInParent<SlotSwitch>();
            slotSwitch.onChange.AddListener(onSlotChange);
            slotsManager[i] = slot.GetComponentInParent<ManagerSingleSlot>();
        }
    }


    public bool HaveEmptySlot()
    {        
        return GameObject.FindGameObjectsWithTag(TagEmpty).Length > 0;
    }

    private ManagerSingleSlot FindEmptySlot()
    {
        return GameObject.FindGameObjectWithTag(TagEmpty).GetComponentInParent<ManagerSingleSlot>();
    }

    public void RollNewDice()
    {
        if (!HaveEmptySlot())
        {
            Debug.LogWarning("not roll becasue not have Empty Slot");
            return;
        }
        
        ManagerSingleSlot emptySlot = FindEmptySlot();
        emptySlot.RollNewDice();        
    }

    public void ClearOccupied()
    {
        foreach(ManagerSingleSlot slot in slotsManager)
        {
            slot.ClearOccupied();
        }
    }

    public void ReRoll()
    {
        foreach (ManagerSingleSlot slot in slotsManager)
        {
            slot.ReRoll();
        }
    }

    private void onSlotChange()
    {
        onChange.Invoke();
    }
}
