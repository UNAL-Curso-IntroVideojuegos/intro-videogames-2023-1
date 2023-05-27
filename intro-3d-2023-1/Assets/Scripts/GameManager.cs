using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //Gameplay
    private int _score = 0;
    private int _level = 0;
    private int _time = 0;
    
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        } 
    }


    private void Start()
    {
        HandleMenu();

        GameEvents.OnEnemyDeathEvent += OnEnemyDeath;
    }

    private void OnDestroy()
    {
        GameEvents.OnEnemyDeathEvent -= OnEnemyDeath;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleMenu();
        }
    }

    public void StartGame()
    {
        HandleGameplay();
    }
    
    public void GameOver()
    {
        Debug.Log("Game over");
        HandleMenu();
    }

    void HandleMenu()
    {
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("Menu");
        AudioManager.Instance.PlayMusic(AudioMusicType.Menu);
    }
    
    void HandleGameplay()
    {
        Debug.Log("Loading Gameplay...");

        _score = 0;
        
        StartCoroutine(LoadGameplayAsyncScene("Gameplay"));
    }
    
    IEnumerator LoadGameplayAsyncScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        yield return new WaitForSeconds(3f);
        
        // if(GameEvents.OnStartGameEvent != null)
        //     GameEvents.OnStartGameEvent.Invoke();
        GameEvents.OnStartGameEvent?.Invoke();
        AudioManager.Instance.PlayMusic(AudioMusicType.Gameplay);
    }


    private void OnEnemyDeath(Enemy enemy, int points)
    {
        _score += points;
        GameEvents.OnPlayerScoreChangeEvent?.Invoke(_score);
    }


}
