using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public List<string> games;
    public Canvas UICanvas;

    private string currentlyLoaded = null;
    public bool gameOver = false;

    public static GameController instance;

    GameController()
    {
        instance = this;
    }

    void Load(string game)
    {
        if (currentlyLoaded != null)
        {
            SceneManager.UnloadScene(currentlyLoaded);
        }
        
        currentlyLoaded = game;
        SceneManager.LoadScene(game, LoadSceneMode.Additive);
        UICanvas.worldCamera = Camera.main;
        TimeBar.instance.ResetTime();
    }

    void LoadRandom()
    {
        string game = games[Random.Range(0, games.Count)];
        Load(game);
    }
    
    void Start()
    {
        LoadRandom();
    }

    private void FixedUpdate()
    {
        if (gameOver)
        {
            return;
        }
        var minigame = FindObjectOfType<MinigameController>();
        if (minigame == null)
        {
            return;
        }
        if (minigame.IsWon())
        {
            Scoreboard.instance.score++;
            LoadRandom();
        } else if (minigame.IsLost())
        {
            Lives.instance.lives--;
            LoadRandom();
        }

        if (TimeBar.instance.time == 0)
        {
            Lives.instance.lives--;
            LoadRandom();
        }

        if (Lives.instance.lives <= 0)
        {
            gameOver = true;
            Load("Game Over");
        }
    }
}
