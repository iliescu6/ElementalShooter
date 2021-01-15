using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody body;
    [SerializeField] float speed;
    [SerializeField] float damage;

    // Update is called once per frame
    void Update()
    {
        body.velocity = transform.up * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            BasicEnemy be = other.gameObject.GetComponent<BasicEnemy>();
            be.LoseHealth(damage);
            Destroy(gameObject);
        }
    }
}
