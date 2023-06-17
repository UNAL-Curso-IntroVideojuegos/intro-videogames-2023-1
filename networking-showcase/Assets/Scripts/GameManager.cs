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
        private Dictionary<ulong, SpaceShip> _playersShipDict;

        public bool IsGamePlaying => State.Value == GameState.GamePlaying;

        private void Awake()
        {
            Instance = this;
            State.Value = GameState.WaitingToStart;
            _playerReadyDict = new Dictionary<ulong, bool>();
            _playersShipDict = new Dictionary<ulong, SpaceShip>();

            GameDelegates.LocalPlayerSpawned += OnLocalPlayerReady;

            UIDelegates.StartGameButtonPressed += OnStartGameButtonPressed;
        }

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();

            State.OnValueChanged += OnStateChanged;

            if(!IsServer)
                return;
            
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
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
            if (CheckGameOver())
                State.Value = GameState.GameOver;
        }
        private void HandleGameOver()
        {
            
        }

        private bool CheckGameOver()
        {
            int shipsAlive = 0;
            foreach (ulong clientID in NetworkManager.Singleton.ConnectedClientsIds)
            {
                SpaceShip playerShip;
                if (!_playersShipDict.TryGetValue(clientID, out playerShip))
                    continue;
                
                if(playerShip && playerShip.HealthPoints > 0)
                    shipsAlive++;
            }
            
            return shipsAlive <= 1;
        }
        
        
        private void OnStartGameButtonPressed()
        {
            SetPlayerReadyServerRpc();
        }

        private void OnLocalPlayerReady(SpaceShip player)
        {
        }

#region NetCallbacks
        private void OnStateChanged(GameState previousvalue, GameState newvalue)
        {
            GameDelegates.EmitGameStateChanged(newvalue);
        }
        
        private void OnClientConnected(ulong clientID)
        { 
            NetworkClient client = NetworkManager.Singleton.ConnectedClients[clientID];
            if (client.PlayerObject.TryGetComponent(out SpaceShip playerShip))
            {
                _playersShipDict[clientID] = playerShip;
            }
        }
        
#endregion

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

            if (NetworkManager.Singleton.ConnectedClientsIds.Count > 1 && allClientsReady)
                State.Value = GameState.GamePlaying;
        }
#endregion
    }
}