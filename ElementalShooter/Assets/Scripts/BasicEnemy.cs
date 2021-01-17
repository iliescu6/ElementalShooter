using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] GameObject bullet;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D body;

    private void Start()
    {
        body.velocity=transform.up*speed;
    }


    public void LoseHealth(float bulletDamage)
    {
        health -= bulletDamage;
        if (health <= 0)
        {
            HUDGameScreen.Instance.AddToScore(5);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBarrier")
        {
            Destroy(gameObject);
        }
    }
}
