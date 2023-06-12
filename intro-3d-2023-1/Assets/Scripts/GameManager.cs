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
    private float _time = 0;
    
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
        MainMenu();

        GameEvents.OnEnemyDeathEvent += OnEnemyDeath;
        GameEvents.OnLevelProgressEvent += OnLevelProgress;

        string rankData = PlayerPrefs.GetString("Rank");
        Debug.Log(rankData);
        loadRank = JsonUtility.FromJson<RankData>(rankData);
    }

    public RankData loadRank;

    private void OnDestroy()
    {
        GameEvents.OnEnemyDeathEvent -= OnEnemyDeath;
        GameEvents.OnLevelProgressEvent -= OnLevelProgress;
        
        string rankData = JsonUtility.ToJson(loadRank);
        PlayerPrefs.SetString("Rank", rankData);
    }
    

    public void StartGame()
    {
        HandleGameplay();
    }
    
    public void MainMenu()
    {
        HandleMenu();
    }
    
    public void GameOver()
    {
        Debug.Log("Game over");
        _time = Time.time - _time;
        int maxScore = PlayerPrefs.GetInt("MaxScore", 0);
        if (_score > maxScore)
        {
            PlayerPrefs.SetInt("MaxScore", _score);
        }
        
        GameEvents.OnGameOverEvent?.Invoke(_score, _score > maxScore, _time, _level);
        
        //TODO: Music end
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
        
        yield return new WaitForSeconds(1f);

        _time = Time.time;
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

    void OnLevelProgress(int level)
    {
        _level = level + 1;
    }


    public Rank rank;

    [ContextMenu("Save rank")]
    public void SaveRank()
    {
        string rankData = JsonUtility.ToJson(rank, true);
        Debug.Log(rankData);
        PlayerPrefs.SetString("Rank", rankData);
    }

    [ContextMenu("Load rank")]
    public void LoadRank()
    {
        string rankData = PlayerPrefs.GetString("Rank");
        rank = JsonUtility.FromJson<Rank>(rankData);
    }

}

[Serializable]
public class Rank
{
    public List<RankUser> users;
}

[Serializable]
public class RankUser
{
    public int score;
    public string name;
}