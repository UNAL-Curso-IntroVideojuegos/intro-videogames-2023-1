using System;
using System.Collections;
using System.Collections.Generic;
using SpaceShipNetwork.Events;
using Unity.Netcode;
using UnityEngine;
using static SpaceShipNetwork.Gameplay.GameState;

namespace SpaceShipNetwork.Gameplay
{
    public enum GameState
    {
        WaitingToStart,
        GamePlaying,
        GameOver
    }
    
    public class GameManager : NetworkBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        private NetworkVariable<GameState> State = new NetworkVariable<GameState>(WaitingToStart);
        private Dictionary<ulong, bool> _playerReadyDict;

        public bool IsGamePlaying => State.Value == GameState.GamePlaying;

        private void Awake()
        {
            Instance = this;
            State.Value = GameState.WaitingToStart;
            _playerReadyDict = new Dictionary<ulong, bool>();

            GameDelegates.LocalPlayerSpawned += OnLocalPlayerReady;

            UIDelegates.StartGameButtonPressed += OnStartGameButtonPressed;
        }

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();

            State.OnValueChanged += OnStateChanged;
        }
        
        private void Update()
        {
            if(!IsServer)
                return;

            switch (State.Value)
            {
                case GameState.WaitingToStart:
                    HandleWaitingToStart();
                    break;
                case GameState.GamePlaying:
                    HandleGamePlaying();
                    break;
                case GameState.GameOver:
                    HandleGameOver();
                    break;
                default:
                    break;
            }
        }

        private void HandleWaitingToStart()
        {
            
        }
        private void HandleGamePlaying()
        {
            
        }
        private void HandleGameOver()
        {
            
        }

        private void OnStateChanged(GameState previousvalue, GameState newvalue)
        {
            GameDelegates.EmitGameStateChanged(newvalue);
        }
        
        private void OnStartGameButtonPressed()
        {
            SetPlayerReadyServerRpc();
        }

        private void OnLocalPlayerReady(SpaceShip player)
        {
        }

#region RPCs
        [ServerRpc(RequireOwnership = false)]
        private void SetPlayerReadyServerRpc(ServerRpcParams serverRpcParams = default)
        {
            _playerReadyDict[serverRpcParams.Receive.SenderClientId] = true;

            bool allClientsReady = true;
            foreach (ulong clientID in NetworkManager.Singleton.ConnectedClientsIds)
            {
                if (!_playerReadyDict.ContainsKey(clientID) || !_playerReadyDict[clientID])
                    allClientsReady = false;
            }

            if (allClientsReady)
                State.Value = GameState.GamePlaying;
        }
#endregion
    }
}