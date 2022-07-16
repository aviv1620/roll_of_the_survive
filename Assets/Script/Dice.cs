using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dice : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject UiDice;

    public Transform selectedSlot;
    public Transform parentcanves;
    public Transform DiceMainObj;

    public void OnBeginDrag(PointerEventData eventData)//IBeginDragHandler, IDragHandler and IEndDragHandler need to make OnDrop call in ResAdder
    {               
    }

    public void OnDrag(PointerEventData eventData)//IBeginDragHandler, IDragHandler and IEndDragHandler need to make OnDrop call in ResAdder
    {       
    }

    public void OnEndDrag(PointerEventData eventData)//IBeginDragHandler, IDragHandler and IEndDragHandler need to make OnDrop call in ResAdder
    {       
    }

   
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        DiceMainObj.SetParent(selectedSlot);        
        UiDice.SetActive(true);
    }

   
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        StartCoroutine(DeActiveUi());      
    }

    private IEnumerator DeActiveUi()
    {       
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();         
        UiDice.SetActive(false);
        DiceMainObj.SetParent(parentcanves);
    }
}
