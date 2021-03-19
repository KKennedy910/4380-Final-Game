using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceController : MonoBehaviour
{
    [SerializeField]
    private RaceCanvasController raceCanvasController;
    [SerializeField]
    private LapTracker Player;
    [SerializeField]
    private LapTracker NPCBlue;
    [SerializeField]
    private LapTracker NPCYellow;
    [SerializeField]
    private LapTracker NPCGreen;
    [SerializeField]
    private TextMeshProUGUI FirstPlaceRacer;
    [SerializeField]
    private TextMeshProUGUI SecondPlaceRacer;
    [SerializeField]
    private TextMeshProUGUI ThirdPlaceRacer;
    [SerializeField]
    private TextMeshProUGUI FourthPlaceRacer;
    [SerializeField]
    private TextMeshProUGUI FirstPlaceTime;
    [SerializeField]
    private TextMeshProUGUI SecondPlaceTime;
    [SerializeField]
    private TextMeshProUGUI ThirdPlaceTime;
    [SerializeField]
    private TextMeshProUGUI FourthPlaceTime;
    private string currentTrack = "Track1";

    private int trackLaps = 5;
    public LapTracker[] PlacementTracker { get; private set; } = new LapTracker[4];
    private int finishingIndex = 0;
    private float currentTime = -5f;
    public TimeSpan convertedTime { get; private set; }
    private void Update()
    {
        currentTime += Time.deltaTime;
        convertedTime = TimeSpan.FromSeconds(currentTime);

        if(Player.currentLap == trackLaps)
        {
            PlacementTracker[finishingIndex] = Player;
            Player.currentLap = -9999;
            if (HighScores.BestTimes[currentTrack] == 0f || currentTime < HighScores.BestTimes[currentTrack])
            {
                HighScores.BestTimes[currentTrack] = currentTime;
            }
            if (HighScores.BestPlacings[currentTrack] > finishingIndex + 1)
            {
                HighScores.BestPlacings[currentTrack] = finishingIndex + 1;
            }
            UpdatePostRaceScreen(finishingIndex, "Player");
            finishingIndex++;
        }
        if (NPCBlue.currentLap == trackLaps)
        {
            PlacementTracker[finishingIndex] = NPCBlue;
            NPCBlue.currentLap = -9999;
            UpdatePostRaceScreen(finishingIndex, "Blue");
            finishingIndex++;
        }
        if (NPCYellow.currentLap == trackLaps)
        {
            PlacementTracker[finishingIndex] = NPCYellow;
            NPCYellow.currentLap = -9999;
            UpdatePostRaceScreen(finishingIndex, "Yellow");
            finishingIndex++;
        }
        if (NPCGreen.currentLap == trackLaps)
        {
            PlacementTracker[finishingIndex] = NPCGreen;
            NPCGreen.currentLap = -9999;
            UpdatePostRaceScreen(finishingIndex, "Green");
            finishingIndex++;
        }
        if (finishingIndex == 4)
        {
            EndRace();
        }
    }

    private void UpdatePostRaceScreen(int finish, string finisher)
    {
        switch (finishingIndex)
        {
            case 0:
                FirstPlaceRacer.SetText(finisher);
                FirstPlaceTime.SetText(convertedTime.ToString("m':'ss':'ff"));
                break;
            case 1:
                SecondPlaceRacer.SetText(finisher);
                SecondPlaceTime.SetText(convertedTime.ToString("m':'ss':'ff"));
                break;
            case 2:
                ThirdPlaceRacer.SetText(finisher);
                ThirdPlaceTime.SetText(convertedTime.ToString("m':'ss':'ff"));
                break;
            case 3:
                FourthPlaceRacer.SetText(finisher);
                FourthPlaceTime.SetText(convertedTime.ToString("m':'ss':'ff"));
                break;
        }
    }

    private void EndRace()
    {
        raceCanvasController.EndRaceDisplay();
        StartCoroutine(EndRaceDelay());
    }

    IEnumerator EndRaceDelay()
    {
        yield return new WaitForSeconds(5);
    }
    public void ChangeTrackName(string newTrackName) => currentTrack = newTrackName;

}
