using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DiceNum))]
public class FloatingActionButtonsPanelSlot : FloatingActionButtonsPanel
{

    public List<ResourceFloatingActionHolder> resources;

    private DiceNum diceNum;
    void Start()
    {
        diceNum = GetComponent<DiceNum>();
    }



    protected override List<FloatingAction> LoadAction()
    {        
        List<FloatingAction> actionLst = new();

        int value = diceNum.Num;

        for (int i=0; i < resources.Count; i++)
        {
            FloatingAction action = new()
            {
                sprite = resources[i].GetIcon(),
                label = "+" + value,
                action = OnAction
            };

            actionLst.Add(action);
        }       

        return actionLst;
    }

    private void OnAction(int index)
    {
        int value = diceNum.Num;

        resources[index].Add(value);

        ManagerSingleSlot slotManager = GetComponentInParent<ManagerSingleSlot>();
        slotManager.Occupied();
}


}
