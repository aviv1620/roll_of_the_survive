using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveIfTutorialEnable : MonoBehaviour
{
   
    void Start()
    {
        gameObject.SetActive(ManagerSettings.Play_Tutorial);
    }

   
}
