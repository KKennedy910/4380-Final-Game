using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenuController : MonoBehaviour
{
    //Main Menu Text Display
    [SerializeField]
    private GameObject MainMenu;
    [SerializeField]
    private TextMeshProUGUI PlatFormerHighScore;
    [SerializeField]
    private TextMeshProUGUI SpaceShooterHighScore;
    [SerializeField]
    private TextMeshProUGUI BreakoutHighScore;

    //RC Racing Score Display
    [SerializeField]
    private GameObject RCRacingHighScoreMenu;
    [SerializeField]
    private TextMeshProUGUI Track1BestTime;
    [SerializeField]
    private TextMeshProUGUI Track2BestTime;
    [SerializeField]
    private TextMeshProUGUI Track3BestTime;
    [SerializeField]
    private TextMeshProUGUI Track4BestTime;
    [SerializeField]
    private TextMeshProUGUI Track1BestPlacing;
    [SerializeField]
    private TextMeshProUGUI Track2BestPlacing;
    [SerializeField]
    private TextMeshProUGUI Track3BestPlacing;
    [SerializeField]
    private TextMeshProUGUI Track4BestPlacing;

    //Timespan values for menu display
    TimeSpan PlatformerTimeConverted;
    TimeSpan Track1BestConverted;
    TimeSpan Track2BestConverted;
    TimeSpan Track3BestConverted;
    TimeSpan Track4BestConverted;

    private void Awake()
    {
        ConvertRawTimesToTimeSpan();
        PlatFormerHighScore.SetText("Best Time:" + PlatformerTimeConverted.ToString("mm' : 'ss"));
        SpaceShooterHighScore.SetText("High Score: " + HighScores.SpaceShooterHighScore);
        BreakoutHighScore.SetText("High Score: " + HighScores.BreakoutHighScore);
        Track1BestTime.SetText(Track1BestConverted.ToString("mm' : 'ss"));
        Track2BestTime.SetText(Track2BestConverted.ToString("mm' : 'ss"));
        Track3BestTime.SetText(Track3BestConverted.ToString("mm' : 'ss"));
        Track4BestTime.SetText(Track4BestConverted.ToString("mm' : 'ss"));
        Track1BestPlacing.SetText(ConvertPlacingToString(HighScores.BestPlacings["Track1"]));
        Track2BestPlacing.SetText(ConvertPlacingToString(HighScores.BestPlacings["Track2"]));
        Track3BestPlacing.SetText(ConvertPlacingToString(HighScores.BestPlacings["Track3"]));
        Track4BestPlacing.SetText(ConvertPlacingToString(HighScores.BestPlacings["Track4"]));
        MainMenu.SetActive(true);
        RCRacingHighScoreMenu.SetActive(false);
    }


    private void ConvertRawTimesToTimeSpan()
    {
        PlatformerTimeConverted = TimeSpan.FromSeconds(HighScores.PlatformerHighScore);
        Track1BestConverted = TimeSpan.FromSeconds(HighScores.BestTimes["Track1"]);
        Track2BestConverted = TimeSpan.FromSeconds(HighScores.BestTimes["Track2"]);
        Track3BestConverted = TimeSpan.FromSeconds(HighScores.BestTimes["Track3"]);
        Track4BestConverted = TimeSpan.FromSeconds(HighScores.BestTimes["Track4"]);
    }
    private string ConvertPlacingToString(int placing)
    {
        switch (placing)
        {
            case 1:
                return "1st";
            case 2:
                return "2nd";
            case 3:
                return "3rd";
            default:
                return "Last";
        }
    }
    public void SwapViews()
    {
     
        MainMenu.SetActive(!MainMenu.activeSelf);
        RCRacingHighScoreMenu.SetActive(!RCRacingHighScoreMenu.activeSelf);
    }
}
