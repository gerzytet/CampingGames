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

    void LoadRandom()
    {
        if (currentlyLoaded != null)
        {
            SceneManager.UnloadScene(currentlyLoaded);
        }

        string game = games[Random.Range(0, games.Count)];
        currentlyLoaded = game;
        SceneManager.LoadScene(game, LoadSceneMode.Additive);
        UICanvas.worldCamera = Camera.main;
        TimeBar.instance.ResetTime();
    }
    
    void Start()
    {
        LoadRandom();
    }

    private void FixedUpdate()
    {
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
    }
}
