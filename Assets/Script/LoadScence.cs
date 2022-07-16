using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScence : MonoBehaviour
{
    public void foo()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
