using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {


    Rigidbody2D rigidBody;
    public float speed = 5f;
    public int jumpCount;//double jump
    public int maxHeight;
    private int currentHeight;

    bool getDamage;

    public int CurrentHeight
    {
        get { return currentHeight; }
    }

    // Use this for initialization
    void Start () {
        getDamage = false;  
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        currentHeight = (int)transform.position.y;

        if (getDamage)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }

        if (maxHeight < currentHeight)
        {
            maxHeight = currentHeight;
        }

        Move();
    }

    /// <summary>
    /// Move function
    /// </summary>
    void Move()
    {
        rigidBody.velocity = new Vector2(3f * speed * Input.GetAxis("Horizontal"), rigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount > 0)// && isPlay
            {
                jumpCount--;
                rigidBody.velocity = Vector2.up * speed * 5f;

            }

        }
        else
        {
            rigidBody.velocity -= Vector2.up;
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(10))
        {

            getDamage = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(8))
        {
            if (collision.gameObject.transform.position.y < gameObject.transform.position.y)
            {
                jumpCount = 1;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            getDamage = false;
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

}
