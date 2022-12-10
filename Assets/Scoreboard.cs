using System;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public int score = 0;
    public static Scoreboard instance;

    public Scoreboard()
    {
        instance = this;
    }

    private void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Score : " + score;
    }
}
