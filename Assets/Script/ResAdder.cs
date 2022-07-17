using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class ResAdder : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent ptrEnter;
    public UnityEvent ptrExit;

    public UnityEvent drop;


    public TMP_Text label;
    private int vlaue;
    public Resource resource;


    private void OnEnable()
    {
        DiceNum diceNum = GetComponentInParent<DiceNum>();
        vlaue = diceNum.num;
        label.text = "+" + vlaue;
    }

    public void OnDrop(PointerEventData data)
    {
        /*if (data.pointerDrag != null)
        {
          
            Debug.Log("Dropped object was: " + data.pointerDrag);
        }*/

        resource.Add(vlaue);
        SlotManager slotManager = GetComponentInParent<SlotManager>();
        slotManager.Occupied();

        drop.Invoke();
        ptrExit.Invoke();
    }


    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        ptrEnter.Invoke();
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        ptrExit.Invoke();
    }
}
