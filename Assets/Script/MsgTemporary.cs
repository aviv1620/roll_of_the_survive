using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class MsgTemporary : MonoBehaviour
{
    public float time = 1f;
   public void play( string msg)
    {
        gameObject.SetActive(true);
        StartCoroutine(WaitToEnd( msg));
    }


    private IEnumerator WaitToEnd(string msg)
    {
        TMP_Text lable = GetComponent<TMP_Text>();
        lable.text = msg;
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        lable.text = "000";
    }
}
