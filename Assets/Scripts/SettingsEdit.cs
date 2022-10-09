using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsEdit : MonoBehaviour
{
    [HideInInspector]
    public bool default_Play_Tutorial;
    [HideInInspector]
    public int default_Cost_Dice;
    [HideInInspector]
    public int default_Days_To_Recue;
    [HideInInspector]
    public bool default_Play_Choose_Seeds;
    [HideInInspector]
    public int default_Seed_Dices;
    [HideInInspector]
    public int default_Seed_Level;
    [HideInInspector]
    public int default_Seed_Animation;


    public Toggle toggleTutorial;
    public TMP_InputField CostDice;
    public TMP_InputField DayesRescue;

    public Toggle chooseSeeds;
    public TMP_InputField seedDices;
    public TMP_InputField seedLevel;
    public TMP_InputField seedAnimation;

    // Start is called before the first frame update
    void Start()
    {
        //get  default
        default_Play_Tutorial = ManagerSettings.Play_Tutorial;
        default_Cost_Dice = ManagerSettings.Cost_Dice;
        default_Days_To_Recue = ManagerSettings.Days_To_Recue;

        default_Play_Choose_Seeds = ManagerSettings.Play_Choose_Seeds;

        default_Seed_Dices = ManagerSettings.Seed_Dices;
        default_Seed_Level = ManagerSettings.Seed_Level;
        default_Seed_Animation = ManagerSettings.Seed_Animation;

        //listener
        toggleTutorial.onValueChanged.AddListener(Tutorial);
        CostDice.onValueChanged.AddListener(CostDiceCange);
        DayesRescue.onValueChanged.AddListener(DayesRescueCange);
        chooseSeeds.onValueChanged.AddListener(chooseSeedsCange);
        seedDices.onValueChanged.AddListener(seedDicesCange);
        seedLevel.onValueChanged.AddListener(seedLevelCange);
        seedAnimation.onValueChanged.AddListener(seedAnimationCange);

        //RestoreDefault To Ui
        RestoreDefault();
    }


    public void RestoreDefault()
    {
        toggleTutorial.isOn = default_Play_Tutorial;
        CostDice.text = default_Cost_Dice.ToString();
        DayesRescue.text = default_Days_To_Recue.ToString();

        chooseSeeds.isOn = default_Play_Choose_Seeds;

        RestoreDefaultSeed();       
    }

    public void RestoreDefaultSeed()
    {
        seedDices.text = default_Seed_Dices.ToString();
        seedLevel.text = default_Seed_Level.ToString();
        seedAnimation.text = default_Seed_Animation.ToString();
    }


    private void Tutorial(bool value)
    {
        ManagerSettings.Play_Tutorial = value;
    }

    private void CostDiceCange(string value)
    {
        if (System.Int32.TryParse(value, out int num))
            ManagerSettings.Cost_Dice = num;
    }

    private void DayesRescueCange(string value)
    {
        if (System.Int32.TryParse(value, out int num))
            ManagerSettings.Days_To_Recue = num;
    }

    private void chooseSeedsCange(bool value)
    {
        ManagerSettings.Play_Choose_Seeds = value;

        seedDices.interactable = value;
        seedLevel.interactable = value;
        seedAnimation.interactable = value;

        if (value == false)
        {
            ManagerSettings.Seed_Dices = default_Seed_Dices;
            ManagerSettings.Seed_Level = default_Seed_Level;
            ManagerSettings.Seed_Animation = default_Seed_Animation;
            RestoreDefaultSeed();
        }
    }

    private void seedDicesCange(string value)
    {

        if(System.Int32.TryParse(value,out int num))
            ManagerSettings.Seed_Dices = num;
    }

    private void seedLevelCange(string value)
    {
        if (System.Int32.TryParse(value, out int num))
            ManagerSettings.Seed_Level = num;
    }
    private void seedAnimationCange(string value)
    {
        if (System.Int32.TryParse(value, out int num))
            ManagerSettings.Seed_Animation = num;
    }



}
