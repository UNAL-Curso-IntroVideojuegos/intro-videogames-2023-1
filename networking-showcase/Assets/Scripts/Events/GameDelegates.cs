using System;
using SpaceShipNetwork.Gameplay;

namespace SpaceShipNetwork.Events
{
    public static class GameDelegates
    {
        public static event Action<GameState> GameStateChanged;
        public static void EmitGameStateChanged(GameState gameState) => GameStateChanged?.Invoke(gameState);
        
        public static event Action<SpaceShip> LocalPlayerSpawned;
        public static void EmitLocalPlayerSpawned(SpaceShip localPlayer) => LocalPlayerSpawned?.Invoke(localPlayer);
        
        public static event Action<bool> GameOverWinner;
        public static void EmitGameOverWinner(bool winner) => GameOverWinner?.Invoke(winner);
    }

    public static class UIDelegates
    {
        public static event Action StartGameButtonPressed;
        public static void EmitStartGameButtonPressed() => StartGameButtonPressed?.Invoke();
        
        public static event Action RestartGameButtonPressed;
        public static void EmitRestartGameButtonPressed() => RestartGameButtonPressed?.Invoke();
        
        public static event Action QuitButtonPressed;
        public static void EmitQuitButtonPressed() => QuitButtonPressed?.Invoke();
    }
}