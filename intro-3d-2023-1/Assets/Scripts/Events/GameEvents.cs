using System;
using UnityEngine;

public static class GameEvents
{
    public static Action OnStartGameEvent;
    
    public static Action<int, bool, float, int> OnGameOverEvent; //total score, is max score?, time, level
    public static Action<int> OnPlayerScoreChangeEvent; //current score
    public static Action<int> OnPlayerHealthChangeEvent; // current health
    public static Action<int> OnLevelProgressEvent; //current level
    
    public static Action<Enemy, int> OnEnemyDeathEvent; //enemy, points
}