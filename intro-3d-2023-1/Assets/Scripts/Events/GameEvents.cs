using System;

public static class GameEvents
{
    public static Action OnStartGameEvent;
    
    //Game Over -> points, new max score, time, level
    //Points update
    //Player health update
    
    public static Action<Enemy, int> OnEnemyDeath; //enemy, points
}