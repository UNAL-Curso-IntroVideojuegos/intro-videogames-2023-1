using System;
using SpaceShipNetwork.Gameplay;

namespace SpaceShipNetwork.Events
{
    public static class GameDelegates
    {
        public static event Action<SpaceShip> LocalPlayerSpawned;
        public static void EmitLocalPlayerSpawned(SpaceShip localPlayer) => LocalPlayerSpawned?.Invoke(localPlayer);
    }
}