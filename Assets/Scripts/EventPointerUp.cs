using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class EventPointerUp : MonoBehaviour, IEndDragHandler//FIXME
{
    public UnityEvent myEvent;

    public void OnEndDrag(PointerEventData eventData)
    {
        myEvent.Invoke();
    }
    
}
