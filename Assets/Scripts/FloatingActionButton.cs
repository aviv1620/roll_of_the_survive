using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class FloatingActionButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    public TMP_Text label;

    public Sprite spriteHighlighted;
    private Sprite sprite;

    private Image buttonImg;

    private bool isPointerIn = false;

    private UnityAction<int> action;
    private int actionIndex;

    void Start()
    {
        buttonImg = GetComponent<Image>();
        buttonImg.alphaHitTestMinimumThreshold = 0.5f;
        sprite = buttonImg.sprite;
    }

    public void LoadFloatingAction(FloatingAction floatingAction, int index)
    {
        icon.sprite = floatingAction.sprite;
        label.text = floatingAction.label;

        action = floatingAction.action;
        actionIndex = index;
    }

    void OnDestroy()
    {
        if (isPointerIn)
            OnDrop();
    }

    private void OnDrop()
    {
        action.Invoke(actionIndex);
    }

    public void OnPointerEnter(PointerEventData eventData)
     {
        isPointerIn = true;
        buttonImg.sprite = spriteHighlighted;
    }

     public void OnPointerExit(PointerEventData eventData)
     {
        isPointerIn = false;
        buttonImg.sprite = sprite;
     }


}
