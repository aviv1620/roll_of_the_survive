using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeActiveNoTutorial : MonoBehaviour
{
   
    void Start()
    {
        gameObject.SetActive(SettingsManager.Play_Tutorial);
    }

   
}
