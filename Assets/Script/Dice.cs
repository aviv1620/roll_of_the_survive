using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dice : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{

    private UiDiceManager uiDiceManager;

    private void Start()
    {
        uiDiceManager = GetComponentInParent<UiDiceManager>();
    }

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
        uiDiceManager.ShowUi();       
    }

   
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        Debug.Log("OnPointerUp");
        uiDiceManager.HideUi();
            
    }    
}
