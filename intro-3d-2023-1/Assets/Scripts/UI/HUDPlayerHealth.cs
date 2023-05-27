using System.Collections.Generic;
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
                _hearts[i].color = new Color(0.3f, 0.3f, 0.3f, 1);
            }
        }
    }
}
