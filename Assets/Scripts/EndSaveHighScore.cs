using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSaveHighScore : MonoBehaviour
{
    public Counter dayesCounter;

    private static readonly string highScoreKey = "score";

    public void SaveHighScore()
    {
        int m_Score = PlayerPrefs.GetInt(highScoreKey, 0);
        PlayerPrefs.SetInt(highScoreKey, Mathf.Max(dayesCounter.value, m_Score));

    }
}
