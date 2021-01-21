using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] public SpriteRenderer bulletSprite;//TODO delete after prototype
    [SerializeField] float speed;
    [SerializeField] float damage;
    public string owner = "";

    void Awake()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && owner == "Player")
        {
            BasicEnemy be = collision.gameObject.GetComponent<BasicEnemy>();
            be.LoseHealth(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player" && owner == "Enemy")
        {
            PlayerProfile be = collision.gameObject.GetComponent<PlayerProfile>();
            be.TakeDamage();
        }

        if (collision.gameObject.tag == "BulletBarrier")
        {
            Destroy(gameObject);
        }
    }

    public void SetOwner(string newOwner)
    {
        owner = newOwner;

        if (owner == "Enemy")
        {
            body.velocity = new Vector2(0, -1) * 5;
        }
        else if (owner == "Player")
        {
            body.velocity = new Vector2(0, 1) * 5;
        }
        else
        {
            Debug.LogError("Wrong owner");
        }
    }

}
