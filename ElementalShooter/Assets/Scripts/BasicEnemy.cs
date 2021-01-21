using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] GameObject bullet;
    [SerializeField] float speed;
    [SerializeField] public Rigidbody2D body;
    public UnityEvent OnDeath;

    private void Awake()
    {
        body.velocity=transform.up*speed;
    }


    public void LoseHealth(float bulletDamage)
    {
        health -= bulletDamage;
        if (health <= 0)
        {
            OnDeath.Invoke();
            OnDeath.RemoveAllListeners();
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
