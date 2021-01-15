using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseHealth(float bulletDamage)
    {
        health -= bulletDamage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
