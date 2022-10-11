using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveIfTutorialEnable : MonoBehaviour
{
    public ManagerSettings managerSettings;

    void Start()
    {
        gameObject.SetActive(managerSettings.settingsGame.playTutorial);
    }

   
}
