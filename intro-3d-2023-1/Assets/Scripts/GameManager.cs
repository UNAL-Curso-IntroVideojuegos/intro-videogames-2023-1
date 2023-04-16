using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject _loadingPanel;
    
    public Inventory Inventory = new Inventory();
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HandleGameplay();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleMenu();
        }
    }

    public void GoToMenu()
    {
        HandleMenu();
    }
    
    void HandleMenu()
    {
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("Menu");
    }
    
    void HandleGameplay()
    {
        Debug.Log("Loading Gameplay...");
        StartCoroutine(LoadGameplayAsyncScene());
    }
    
    IEnumerator LoadGameplayAsyncScene()
    { 
        _loadingPanel.SetActive(true);

        //Test
        yield return new WaitForSeconds(3f);
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator FakeUpdate()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(3);
            
        }
    }

}


public class Inventory
{
    public int amount;
}