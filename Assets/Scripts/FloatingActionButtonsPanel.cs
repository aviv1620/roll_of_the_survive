using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class FloatingActionButtonsPanel : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
    public GameObject panelPref;
    public Transform canvasFloatingUi;
    private GameObject panel;

    protected abstract List<FloatingAction> LoadAction();


    public void OnPointerDown(PointerEventData pointerEventData)
    {
        List<FloatingAction> actionLst = LoadAction();

        panel = Instantiate(
            original: panelPref,
            position: transform.position,
            rotation: transform.rotation,
            parent: canvasFloatingUi);

        ManagerSingleFloatingActionButtonsPanel panelManager = panel.GetComponent<ManagerSingleFloatingActionButtonsPanel>();

        panelManager.LoadActionButtons(actionLst);
    }


    public void OnPointerUp(PointerEventData pointerEventData)
    {
        Destroy(panel);       

    }
    
}
