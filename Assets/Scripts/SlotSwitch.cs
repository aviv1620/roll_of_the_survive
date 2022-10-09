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



    public void SwitchTo(SlotMode mode)
    {
        switch (mode)
        {
            case SlotMode.anim:
                EnableOne(anim);
                break;
            case SlotMode.dice:
                EnableOne(dice);
                break;
            case SlotMode.empty:
                EnableOne(empty);
                break;
            case SlotMode.occupied:
                EnableOne(occupied);
                break;
        }
    }

    private void EnableOne(GameObject obj)
    {
        foreach (Transform child in transform)
        {
            bool active = (child.gameObject == obj);
            child.gameObject.SetActive(active);
        }
        onChange.Invoke();
    }
}
