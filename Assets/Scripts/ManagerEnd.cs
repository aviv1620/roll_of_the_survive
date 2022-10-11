using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEnd : MonoBehaviour
{
    //Ui Game Objects need Active to show the end popup window.
    public GameObject[] popupObjs;

    public EndSaveHighScore endSaveHighScore;

    public EndDialogReason endDialogReason;

    public void End(string reasonTemplate)
    {
        foreach(GameObject popupObj in popupObjs)
        {
            popupObj.SetActive(true);
        }

        endSaveHighScore.SaveHighScore();

        endDialogReason.LoadReason(reasonTemplate);

    }
}
