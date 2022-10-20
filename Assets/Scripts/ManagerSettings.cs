using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSettings : MonoBehaviour
{    
    private static readonly string settingsGameKey = "settings";

    [HideInInspector]
    public SettingsGame settingsGame;

    public SettingsGameScriptableObject settingsDefault;

    void Awake()
    {
        Load();
    }

    private void Load()
    {
        string settingsGameDefaultJson = JsonUtility.ToJson(settingsDefault.settingsGame);
        string settingsGameJson = PlayerPrefs.GetString(settingsGameKey, settingsGameDefaultJson);

        settingsGame = JsonUtility.FromJson<SettingsGame>(settingsGameJson);
    }

    public void RestoreDefault()
    {
        string settingsGameDefaultJson = JsonUtility.ToJson(settingsDefault.settingsGame);
        PlayerPrefs.SetString(settingsGameKey, settingsGameDefaultJson);
        Load();
    }

    public void Save(SettingsGame _settingsGame)
    {
        settingsGame = _settingsGame;
        string settingsGameJson = JsonUtility.ToJson(settingsGame);
        PlayerPrefs.SetString(settingsGameKey, settingsGameJson);
    }
}