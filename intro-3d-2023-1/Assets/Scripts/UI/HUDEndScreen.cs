using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDEndScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _timeText;
    [SerializeField]
    private TextMeshProUGUI _levelText;
    [SerializeField]
    private GameObject _newMaxScore;
    [SerializeField] 
    private Button _backButton;


    private CanvasGroup _canvasGroup;
    
    private void Start()
    {
        GameEvents.OnGameOverEvent += OnGameOver;

        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
        
        _backButton.onClick.AddListener(OnButtonBack);
    }

    private void OnDestroy()
    {
        GameEvents.OnGameOverEvent -= OnGameOver;
    }

    private void OnGameOver(int score, bool isMaxScore, float time, int level)
    {
        SetResults(score, isMaxScore, time, level);
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
    }

    void SetResults(int score, bool isMaxScore, float time, int level)
    {
        _scoreText.text = $"Score: {score}";
        _newMaxScore.SetActive(isMaxScore);
        
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        _timeText.text = $"Time: {timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";

        _levelText.text = $"Level: {level}";
    }
    
    void OnButtonBack()
    {
        GameManager.Instance.MainMenu();
    }
}