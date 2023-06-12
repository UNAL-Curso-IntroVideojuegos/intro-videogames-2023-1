using TMPro;
using UnityEngine;
using DG.Tweening;

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
        Vector2 anchorPos = _scoreText.rectTransform.anchoredPosition;
        _scoreText.rectTransform.DOJumpAnchorPos(anchorPos, 25, 1, 0.5f);
    }
    
}
