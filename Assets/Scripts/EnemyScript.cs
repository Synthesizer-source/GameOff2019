using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public GameObject player;
    public float speed;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        Move();


    }

    void Move()
    {

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(8))
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<BoxCollider2D>());
        }

    }


    private void OnParticleCollision(GameObject other)
    {
        if (other.layer.Equals(9))
        {
            
            Destroy(other);
            Destroy(gameObject);

        }
    }
}
