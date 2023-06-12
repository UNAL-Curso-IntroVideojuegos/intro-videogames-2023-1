using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HUDPlayerHealth : MonoBehaviour
{
    private List<Image> _hearts = new List<Image>();

    void Start()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            _hearts.Add(child.GetComponent<Image>());
        }

        GameEvents.OnPlayerHealthChangeEvent += OnPlayerHealthChange;
    }

    private void OnDestroy()
    {
        GameEvents.OnPlayerHealthChangeEvent -= OnPlayerHealthChange;
    }
    
    private void OnPlayerHealthChange(int health)
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            if (i < health)
            {
                _hearts[i].color = Color.white;
            }
            else
            {
                AnimateDamage(_hearts[i]);
            }
        }
    }

    [ContextMenu("test")]
    public void TestAnimation()
    {
        AnimateDamage(_hearts[^1]);
    }

    // public float scaleTarget = 1.1f;
    // public float scaleDuration = 0.8f;
    // public float scaleDownDuration = 0.8f;
    // public Ease scaleEase;
    // public Ease scaleDownEase;
    private void AnimateDamage(Image heart)
    {
        Color c = new Color(0.3f, 0.3f, 0.3f, 1);
        // heart.DOColor(c, 0.5f).SetEase(Ease.InCubic);
        // heart.rectTransform.DOScale(Vector3.one * 1.3f, .3f).SetEase(Ease.InCubic).OnComplete(() =>
        // {
        //     heart.rectTransform.DOScale(Vector3.one, .4f).SetEase(Ease.OutBounce);
        // });

        Sequence s = DOTween.Sequence();
        s.Insert(0,heart.DOColor(c, 0.5f).SetEase(Ease.InCubic));
        s.Insert(0, heart.rectTransform.DOScale(Vector3.one * 1.3f, .3f).SetEase(Ease.InCubic));
        s.Append(heart.rectTransform.DOScale(Vector3.one, .4f).SetEase(Ease.OutBounce));
    }
}
