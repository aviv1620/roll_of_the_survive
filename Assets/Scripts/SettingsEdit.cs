using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(ManagerSettings))]
public class SettingsEdit : MonoBehaviour
{
   
    private SettingsGame settingsGame;

    private ManagerSettings managerSettings;

    public Toggle uiToggleTutorial;
    public TMP_InputField uiInputCostDice;
    public TMP_InputField uiInputDayesRescue;

    public Toggle uiChooseSeeds;
    public TMP_InputField uiInputSeedDices;
    public TMP_InputField uiInputSeedLevel;
    public TMP_InputField uiInputSeedAnimation;
    public Button uiBtnRestoreDefault;

    void Start()
    {
        managerSettings = GetComponent<ManagerSettings>();
        Load(managerSettings.settingsGame);

        //listener
        uiToggleTutorial.onValueChanged.AddListener(OnUiTutorial);
        uiInputCostDice.onValueChanged.AddListener(OnUiCostDice);
        uiInputDayesRescue.onValueChanged.AddListener(OnUiDayesRescue);
        uiChooseSeeds.onValueChanged.AddListener(OnUiChooseSeeds);
        uiInputSeedDices.onValueChanged.AddListener(OnUiSeedDicesCange);
        uiInputSeedLevel.onValueChanged.AddListener(OnUiSeedLevelCange);
        uiInputSeedAnimation.onValueChanged.AddListener(OnUiSeedAnimationCange);
        uiBtnRestoreDefault.onClick.AddListener(OnUiBtnRestoreDefault);
    }

    private void Load(SettingsGame _settingsGame)
    {
        settingsGame = _settingsGame;

        uiToggleTutorial.isOn = settingsGame.playTutorial;
        uiInputCostDice.text = settingsGame.costDice.ToString();
        uiInputDayesRescue.text = settingsGame.daysToRecue.ToString();
        uiChooseSeeds.isOn = settingsGame.playerChooseSeeds;
        
        LoadSeeds();      

    }


    private void LoadSeeds()
    {
        if (!settingsGame.playerChooseSeeds)
        {
            SeedPseudoRandom();

            Save();
        }

        LoadSeedsShow();                          

        LoadSeedsInteractable();
    }

    private void LoadSeedsShow()
    {
        uiInputSeedDices.text = settingsGame.seedDices.ToString();
        uiInputSeedLevel.text = settingsGame.seedLevel.ToString();
        uiInputSeedAnimation.text = settingsGame.seedAnimation.ToString();
    }

    private void LoadSeedsInteractable()
    {
        uiInputSeedDices.interactable = settingsGame.playerChooseSeeds;
        uiInputSeedLevel.interactable = settingsGame.playerChooseSeeds;
        uiInputSeedAnimation.interactable = settingsGame.playerChooseSeeds;
    }


    private void Save()
    {
        managerSettings.Save(settingsGame);
    }


    private void SeedPseudoRandom()
    {
        System.Random rnd = new System.Random();

        settingsGame.seedDices = rnd.Next();
        settingsGame.seedLevel = rnd.Next();
        settingsGame.seedAnimation = rnd.Next();
    }

    private void OnUiTutorial(bool value)
    {
        settingsGame.playTutorial = value;
        Save();        
    }

    private void OnUiCostDice(string value)
    {
        if (System.Int32.TryParse(value, out int num))
            settingsGame.costDice = num;
        Save();
    }

    private void OnUiDayesRescue(string value)
    {
        if (System.Int32.TryParse(value, out int num))
            settingsGame.daysToRecue = num;
        Save();
    }

    private void OnUiChooseSeeds(bool playerChooseSeeds)
    {
        settingsGame.playerChooseSeeds = playerChooseSeeds;

        LoadSeeds();
    }

    private void OnUiSeedDicesCange(string value)
    {

        if(System.Int32.TryParse(value,out int num))
            settingsGame.seedDices = num;
        Save();
    }

    private void OnUiSeedLevelCange(string value)
    {
        if (System.Int32.TryParse(value, out int num))
            settingsGame.seedLevel = num;
        Save();
    }
    private void OnUiSeedAnimationCange(string value)
    {
        if (System.Int32.TryParse(value, out int num))
            settingsGame.seedAnimation = num;
        Save();
    }


    private void OnUiBtnRestoreDefault()
    {
        managerSettings.RestoreDefault();
        Load(managerSettings.settingsGame);
    }



}
