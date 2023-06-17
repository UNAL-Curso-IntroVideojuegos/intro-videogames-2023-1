using SpaceShipNetwork.Events;
using SpaceShipNetwork.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShipNetwork.UI
{
    public class UIStartGameScreen : MonoBehaviour
    {
        [SerializeField] private Button _startBtn;
        
        void Start()
        {
            _startBtn.onClick.AddListener(OnStartButtonPressed);

            GameDelegates.GameStateChanged += OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState gameState)
        {
            if(gameState == GameState.WaitingToStart)
                Show();
            else
                Hide();
        }

        private void OnStartButtonPressed()
        {
            _startBtn.interactable = false;
            UIDelegates.EmitStartGameButtonPressed();
        }
        
        private void Show()
        {
            _startBtn.interactable = true;
            gameObject.SetActive(true);
        }
        
        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}