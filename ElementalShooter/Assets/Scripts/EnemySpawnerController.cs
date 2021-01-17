using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{

    [SerializeField] GameObject hazard;
    [SerializeField] Transform spawningPoint;  
    [SerializeField] float timeBetweenSpawn;
    float spawnTimer = 0;
    public bool waveDefeated = false;

    private void Start()
    {
        StartCoroutine(StarGame());
    }

    IEnumerator StarGame()
    {
        yield return new WaitForSeconds(timeBetweenSpawn);
        while (!waveDefeated)
        {
            Vector3 newSpanPoint = new Vector3(Random.Range(-spawningPoint.position.x, spawningPoint.position.x), spawningPoint.position.y, spawningPoint.position.z);
            Instantiate(hazard, newSpanPoint, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }

    
}
