using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{

    [SerializeField] BasicEnemy hazard;
    [SerializeField] Transform spawningPoint;
    [SerializeField] Transform waveSpawningPoint;
    [SerializeField] float timeBetweenSpawn;
    [SerializeField] WaveFormation waveFormation;
    BasicEnemy[] simpleWave;
    BasicEnemy[,] wave;
    int remainingEnemies;
    float spawnTimer = 0;
    public bool waveDefeated = false;
    public bool bossDefeated = false;
    public float difficultyTimer;
    public float spawnNewWaveTime;
    int difficultyLevel;

    private void Start()
    {
        StartCoroutine(StarGame());
        //MakeRandomWave();
    }
    private void Update()
    {
        difficultyTimer += Time.deltaTime;
        
    }
    IEnumerator StarGame()
    {
        yield return new WaitForSeconds(timeBetweenSpawn);
        while (!bossDefeated)
        {
            //Spawns one random object
            Vector3 newSpanPoint = new Vector3(Random.Range(-spawningPoint.position.x, spawningPoint.position.x), spawningPoint.position.y, spawningPoint.position.z);
            BasicEnemy enemy= Instantiate(hazard, newSpanPoint, Quaternion.identity);
            enemy.SetSpeed();
            if (difficultyTimer > spawnNewWaveTime)
            {
                while (remainingEnemies > 0)
                {
                    yield return new WaitForSeconds(.25f);
                }
                MakeRandomWave();
            }
            while (remainingEnemies > 0)
            {
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }


    void CreateBasicWave()
    {
    }

    //Creaste a wave
    void MakeRandomWave()
    {
        Vector3 cP = waveSpawningPoint.position;
        wave = new BasicEnemy[5, 5];
        if(waveFormation.type==WaveFormationType.OnePerHorizonatlLine)
        for (int i = 0; i < 5; i++)
        {
                waveFormation.CreateWaveFormation(i,1f, cP.y - 1.5f*i,5,cP, RemoveEnemyFromWave);
            //for (int j = 0; j < 5; j++)
            //{
            //    wave[i,j] = Instantiate<BasicEnemy>(hazard, new Vector3(cP.x + .75f * i, cP.y - 1.5f * j, cP.z), Quaternion.identity);
            //    wave[i,j].OnDeath.AddListener(RemoveEnemyFromWave);
            //    wave[i,j].body.velocity = new Vector2(0, 0);
            //}
        }
        remainingEnemies = 5 * 5;
    }

    void SpawnRandomBoss()
    {

    }

    void RemoveEnemyFromWave()
    {
        remainingEnemies--;
        HUDGameScreen.Instance.debugEnemiesLeft = remainingEnemies;
        if (remainingEnemies == 0)
        {
            spawnNewWaveTime = difficultyTimer + 10;
        }
    }
}
