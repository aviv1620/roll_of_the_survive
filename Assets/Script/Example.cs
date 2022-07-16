//Attach this script to the GameObject you would like to have mouse clicks detected on
//This script outputs a message to the Console when a click is currently detected or when it is released on the GameObject with this script attached

using UnityEngine;
using UnityEngine.EventSystems;

public class Example : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
    }
}
