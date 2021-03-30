using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScores
{
    public static float PlatformerHighScore = 0;
    public static float SpaceShooterHighScore = 0;
    public static int BreakoutHighScore = 0;
    public static Dictionary<string, float> BestTimes = new Dictionary<string, float>() {
        {"Track1", 0f},
        {"Track2", 0f},
        {"Track3", 0f},
        {"Track4", 0f}
    };
    public static Dictionary<string, int> BestPlacings = new Dictionary<string, int>() {
        {"Track1", 5},
        {"Track2", 5},
        {"Track3", 5},
        {"Track4", 5}
    };
}
