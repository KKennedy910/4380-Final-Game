using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GrandPrixController
{
    public static int currentTrack = 1;
    public static Dictionary<int, string> TrackStrings = new Dictionary<int, string>(){
        {1, "Track1"},
        {2, "Track2"},
        {3, "Track3"},
        {4, "Track4"}
    };
    public static string GetTrackName()
    {
        Debug.Log(TrackStrings[currentTrack]);
        return TrackStrings[currentTrack];

    }
    public static void IncrementTrackCount()
    {
        currentTrack++;
    }
    public static void ResetGrandPrix()
    {
        currentTrack = 1;
    }
}
    
