using Cinemachine;
using SpaceShipNetwork.Events;
using UnityEngine;

namespace SpaceShipNetwork.Gameplay
{
    public class CameraController : MonoBehaviour
    {
        private CinemachineBrain _cam;

        void Start()
        {
            _cam = GetComponent<CinemachineBrain>();

            GameDelegates.LocalPlayerSpawned += OnLocalPlayerSpawned;
        }

        private void OnDestroy()
        {
            GameDelegates.LocalPlayerSpawned -= OnLocalPlayerSpawned;
        }

        private void OnLocalPlayerSpawned(SpaceShip localPlayer)
        {
            _cam.ActiveVirtualCamera.Follow = localPlayer.transform;
        }
        
    }
}