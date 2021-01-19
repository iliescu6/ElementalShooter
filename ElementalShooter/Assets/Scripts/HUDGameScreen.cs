using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDGameScreen : MonoBehaviour
{
    public static HUDGameScreen Instance;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text debugText;
    [SerializeField] PlayerProfile spaceship;
    [SerializeField] EnemySpawnerController enemySontroller;

    public int score;
    
    private void Awake()
    {
        Instance = this;
        scoreText.text = "0";
    }

    private void Update()
    {
        debugText.text = enemySontroller.difficultyTimer.ToString();
    }

    

    public void AddToScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        //if (score >= 25)
        //{
        //    enemySontroller.waveDefeated = true;
        //}
    }
}
