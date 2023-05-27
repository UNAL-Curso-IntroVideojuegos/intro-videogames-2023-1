using TMPro;
using UnityEngine;

public class HUDPlayerScore : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    
    void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        GameEvents.OnPlayerScoreChangeEvent += OnPlayerScoreChange;
    }

    private void OnDestroy()
    {
        GameEvents.OnPlayerScoreChangeEvent -= OnPlayerScoreChange;
    }


    private void OnPlayerScoreChange(int score)
    {
        _scoreText.text = $"SCORE: {score}";
    }
}
