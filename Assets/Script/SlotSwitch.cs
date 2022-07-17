using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[SerializeField]
public enum SlotMode
{
    anim,dice,empty, occupied
}

public class SlotSwitch : MonoBehaviour
{

    public GameObject anim;
    public GameObject dice;
    public GameObject empty;
    public GameObject occupied;

    [HideInInspector]
    public UnityEvent onChange;



    public void switchTo(SlotMode mode)
    {
        switch (mode)
        {
            case SlotMode.anim:
                EnableOnce(anim);
                break;
            case SlotMode.dice:
                EnableOnce(dice);
                break;
            case SlotMode.empty:
                EnableOnce(empty);
                break;
            case SlotMode.occupied:
                EnableOnce(occupied);
                break;
        }
    }

    private void EnableOnce(GameObject obj)
    {
        foreach (Transform child in transform)
        {
            bool active = child.gameObject == obj;
            child.gameObject.SetActive(active);
        }
        onChange.Invoke();
    }
}
