using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [SerializeField] public float currentHealth;
    [SerializeField] public Transform bulletSpawnPoint;
    [SerializeField] public Bullet bullet;
    [SerializeField] public float speed;
    [SerializeField] public Rigidbody2D body;
    public UnityEvent OnDeath;

    public virtual void Awake()
    {
        currentHealth = maxHealth;
        body.velocity=transform.up*speed;
    }


    public void LoseHealth(float bulletDamage)
    {
        currentHealth -= bulletDamage;
        HUDGameScreen.Instance.UpdateLifeBar(currentHealth/maxHealth);
        if (currentHealth <= 0)
        {
            OnDeath.Invoke();
            OnDeath.RemoveAllListeners();
            HUDGameScreen.Instance.AddToScore(5);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBarrier")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator BasicMovement()
    {
        yield return new WaitForSeconds(1);
    }
}
