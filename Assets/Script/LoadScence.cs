using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScence : MonoBehaviour
{
    public void foo(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}
