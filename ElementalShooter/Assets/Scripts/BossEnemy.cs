using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossEnemy : BasicEnemy
{
    //Set behaviour to each one of these and the boss will run them based on hp?
    UnityAction levelOneAction;
    UnityAction levelTwoAction;
    UnityAction levelThreeAction;
    UnityAction specialityAction;
    float bossTimer = 0;
    public override void Awake()
    {
        currentHealth = maxHealth;
        body.velocity = transform.right * speed;
        StartCoroutine(BossLogic());
    }

    public void Update()
    {
        bossTimer += Time.deltaTime;
    }

    //How to do circle of bullets idea, use bullet spawning point and rotate it per bullet

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("sdkngijdsg");
        if (collision.gameObject.tag == "HorizontalBoundary")
        {
            speed = -speed;
            body.velocity = transform.right * speed;
        }
    }

    IEnumerator BossLogic()
    {
        yield return new WaitForSeconds(2);
        while (currentHealth > 0)
        {
            if (bossTimer >= 2)
            {
                ShootBullet();
                bossTimer = 0;               
            }
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }

    public void ShootBullet()
    {
        Bullet b= Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
        b.SetOwner("Enemy");
    }
}
