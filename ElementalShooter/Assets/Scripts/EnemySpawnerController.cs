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
    BasicEnemy[] simpleWave;
    BasicEnemy[,] wave;
    int remainingEnemies;
    float spawnTimer = 0;
    public bool waveDefeated = false;
    public float difficultyTimer;
    int difficultyLevel;

    private void Start()
    {
        StartCoroutine(StarGame());
    }
    private void Update()
    {
        difficultyTimer += Time.deltaTime;
        
    }
    IEnumerator StarGame()
    {
        yield return new WaitForSeconds(timeBetweenSpawn);
        while (!waveDefeated)
        {
            Vector3 newSpanPoint = new Vector3(Random.Range(-spawningPoint.position.x, spawningPoint.position.x), spawningPoint.position.y, spawningPoint.position.z);
            Instantiate(hazard, newSpanPoint, Quaternion.identity);
            if (difficultyTimer > 5)
            {
                MakeRandomWave();
            }
            while (remainingEnemies > 0)
            {
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }


    void MakeRandomWave()
    {
        Vector3 cP = waveSpawningPoint.position;
        wave = new BasicEnemy[5, 5];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                wave[i,j] = Instantiate<BasicEnemy>(hazard, new Vector3(cP.x + .75f * i, cP.y - 1.5f * j, cP.z), Quaternion.identity);
                wave[i,j].OnDeath.AddListener(RemoveEnemyFromWave);
                wave[i,j].body.velocity = new Vector2(0, 0);
            }
        }
        remainingEnemies = 5 * 5;
    }

    void RemoveEnemyFromWave()
    {
        remainingEnemies--;
    }
}
