using SpaceShipNetwork.Events;
using SpaceShipNetwork.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShipNetwork.UI
{
    public class UIGameOver : MonoBehaviour
    {
        [SerializeField] private Button _restartBtn;
        [SerializeField] private Button _quitBtn;
        [SerializeField] private GameObject _winnerLabel;
        [SerializeField] private GameObject _loserLabel;

        private void Start()
        {
            _restartBtn.onClick.AddListener(OnRestartButtonPressed);
            _quitBtn.onClick.AddListener(OnQuitButtonPressed);
            GameDelegates.GameStateChanged += OnGameStateChanged;
            GameDelegates.GameOverWinner += OnGameOverWinner;
            
            Hide();
        }
        
        private void OnGameStateChanged(GameState gameState)
        {
            if(gameState == GameState.GameOver)
                Show();
            else
                Hide();
        }
        
        private void OnGameOverWinner(bool winner)
        {
            _winnerLabel.SetActive(winner);
            _loserLabel.SetActive(winner);
        }

        private void OnRestartButtonPressed()
        {
            Hide();
            UIDelegates.EmitRestartGameButtonPressed();
        }
        
        private void OnQuitButtonPressed()
        {
            Hide();
            UIDelegates.EmitQuitButtonPressed();
        }
        
        private void Show()
        {
            gameObject.SetActive(true);
        }
        
        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}