using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] public SpriteRenderer bulletSprite;//TODO delete after prototype
    [SerializeField] float speed;
    [SerializeField] float damage;

    void Update()
    {
        body.velocity = new Vector2(0,1) * 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            BasicEnemy be = collision.gameObject.GetComponent<BasicEnemy>();
            be.LoseHealth(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "BulletBarrier")
        {
            Destroy(gameObject);
        }
    }

}
