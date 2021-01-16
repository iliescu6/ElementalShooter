using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform initialSpawnPoint;
    [SerializeField] GameObject enemy;
    
    void Awake()
    {
        Vector3 cP = initialSpawnPoint.position;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Instantiate(enemy, new Vector3(cP.x+.75f*i, cP.y-1.5f*j, cP.z), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
