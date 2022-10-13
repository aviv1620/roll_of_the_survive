using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ManagerSingleFloatingActionButtonsPanel : MonoBehaviour
{
    static private readonly float AngleStart = 135f;
    static private readonly float AngleAdd = -90;

    private List<FloatingAction> floatingActionButtons;
    public GameObject floatingActionButtonPref;

    public void LoadActionButtons(List<FloatingAction> _floatingActionButtons)
    {
        floatingActionButtons = _floatingActionButtons;

        if (floatingActionButtons.Count > 4)
        {
            Debug.LogError("Floating action buttons panel can hold only 4 buttons or less.");
            return;
        }       

        for (int i=0; i < floatingActionButtons.Count; i++)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, AngleStart + AngleAdd * i);

            GameObject floatingActionButtonObj = Instantiate(
                original: floatingActionButtonPref,
                position: transform.position,
                rotation: rotation,
                parent: transform);

            FloatingActionButton floatingActionButton = floatingActionButtonObj.GetComponent<FloatingActionButton>();

            floatingActionButton.LoadFloatingAction(floatingActionButtons[i],i);
        }       
    }  
}
