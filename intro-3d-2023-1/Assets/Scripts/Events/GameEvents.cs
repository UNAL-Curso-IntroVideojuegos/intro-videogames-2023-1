using System;
using UnityEngine;

public static class GameEvents
{
    public static Action OnStartGameEvent;
    
    //Game Over -> points, new max score, time, level
    public static Action<int> OnPlayerScoreChangeEvent; //current score
    public static Action<int> OnPlayerHealthChangeEvent; // current health
    
    public static Action<Enemy, int> OnEnemyDeathEvent; //enemy, points
}