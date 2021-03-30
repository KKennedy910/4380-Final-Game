using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RaceCanvasController : MonoBehaviour
{
    [SerializeField]
    private RaceController raceController;
    [SerializeField]
    private LapTracker player;
    [SerializeField]
    private TextMeshProUGUI Timer;
    [SerializeField]
    private TextMeshProUGUI Lap;
    [SerializeField]
    private GameObject MainDisplay;
    [SerializeField] 
    private GameObject PostRaceDisplay;
    [SerializeField]
    private GameObject PreRaceCanvas;
    [SerializeField]
    private TextMeshProUGUI PreRaceTimer;
    private float countdownReal = 5f;
    private TimeSpan countdownTimer;
    private bool hasRaceStarted;

    private void Start()
    {
        StartRace();
    }
    void Update()
    {
        if (!hasRaceStarted)
        {
            countdownReal -= Time.deltaTime;
            countdownTimer = TimeSpan.FromSeconds(countdownReal);
            PreRaceTimer.SetText(countdownTimer.ToString("s'.'ff"));
            if (countdownReal <= 0)
            {
                PreRaceCanvas.SetActive(false);
                MainDisplay.SetActive(true);
                hasRaceStarted = true;
            }
        }
        Timer.text = raceController.convertedTime.ToString("m':'ss'.'ff");
        if (player.currentLap > 0)
            Lap.text = "Current Lap: " + player.currentLap;
        else
            Lap.text = "Race Complete!";
    }

    public void EndRaceDisplay()
    {
        MainDisplay.SetActive(false);
        PostRaceDisplay.SetActive(true);
    }
    public void StartRace()
    {
        PostRaceDisplay.SetActive(false);
        MainDisplay.SetActive(false);
    }
}
