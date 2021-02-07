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
    private Vector2 currentPoint;
    int index = 0;
    public UnityEvent OnDeath;

    public virtual void Awake()
    {
        currentHealth = maxHealth;
        //body.velocity=transform.up*speed;
    }

    public void Start()
    {
       // currentPoint = pathCreator.path.points[0];
    }
    private void Update()
    {
        //if (Vector2.Distance(transform.position, currentPoint) < 0.2)
        //{
        //    //if (index + 1 < pathCreator.path.points.Count)
        //    //{
        //    //    index++;
        //    //}
        //    //currentPoint = pathCreator.path.points[index];
        //}
        //else
        //{
        //    transform.position=Vector2.MoveTowards(transform.position, currentPoint, 1*Time.deltaTime);
        //}
    }

    public void SetSpeed()
    {
        body.velocity = transform.up * speed;
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
