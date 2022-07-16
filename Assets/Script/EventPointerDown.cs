using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class EventPointerDown : MonoBehaviour, IBeginDragHandler,IPointerDownHandler, IDragHandler//FIXME
{
    public UnityEvent myEvent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        myEvent.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}
