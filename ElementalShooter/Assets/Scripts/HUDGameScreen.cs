using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDGameScreen : MonoBehaviour
{
    public static HUDGameScreen Instance;
    [SerializeField] Image bossHealth;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text debugText;
    [SerializeField] PlayerProfile spaceship;
    [SerializeField] EnemySpawnerController enemyController;
    public int debugEnemiesLeft = 0;

    public int score;
    
    private void Awake()
    {
        Instance = this;
        scoreText.text = "0";
    }

    private void Update()
    {
        debugText.text = enemyController.difficultyTimer.ToString() + "\n"+ debugEnemiesLeft;
    }


    public void UpdateLifeBar(float percentage)
    {
        if (bossHealth.gameObject.activeInHierarchy)
        {
            bossHealth.fillAmount = percentage;
        }
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
