using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTest : MonoBehaviour
{
    public float _speed;
    public RectTransform _rect;

    public RectTransform[] _path;

    private Coroutine _moveCoroutine;
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            CancelMove();
            _moveCoroutine = StartCoroutine(Move());
        }
    }

    private IEnumerator Move()
    {
        _rect.anchoredPosition = _path[0].anchoredPosition;
        for (int i = 1; i < _path.Length; i++)
        {
            Vector2 initPos = _rect.anchoredPosition;
            Vector2 target = _path[i].anchoredPosition;
            float percent = 0;
            while (percent <= 1)
            {
                percent += _speed * Time.deltaTime;
                float interpolation = OutElastic(percent);
                _rect.anchoredPosition = Vector2.LerpUnclamped(initPos, target, interpolation);
                yield return null;
            }
        }
        
    }

    private void CancelMove()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }
    }

    private float OutBack(float x)
    {
        float c1 = 1.70158f;
        float c3 = c1 + 1;

        return 1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
    }

    private float OutCubic(float x)
    {
        return 1 - Mathf.Pow(1 - x, 3);
    }
    
    private float OutElastic(float x){
        float c4 = (2 * Mathf.PI) / 3;

        return x == 0 ? 0 : x == 1 ? 1 : Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10 - 0.75f) * c4) + 1;

    }
}
