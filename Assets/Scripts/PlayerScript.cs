﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {


    Rigidbody2D rigidBody;
    public float speed = 5f;
    public int jumpCount;//double jump
    public int maxHeight;
    private int currentHeight;
    public GameObject jump;
    Vector3 jumpOffset;
    AudioSource audioSource;
    public AudioClip audioJump;

    private bool onGround;

    private int kill;

    private bool getDamage;

    public int CurrentHeight
    {
        get { return currentHeight; }
    }

    public int Kill
    {
        set { kill = value; }
        get { return kill; }
    }

    public bool GetDamage
    {
        get { return getDamage; }
    }

    public bool OnGround
    {
        get { return onGround; }
    }

    // Use this for initialization
    void Start () {
        
        audioSource = GetComponent<AudioSource>();
        kill = 0;
        getDamage = false;  
        rigidBody = GetComponent<Rigidbody2D>();
        jumpOffset = new Vector3(0f, -0.35f, -1.5f);
    }
	
	// Update is called once per frame
	void Update () {

        if (GameManagerScript.isPlay)
        {
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
        
    }

    /// <summary>
    /// Move function
    /// </summary>
    void Move()
    {
        rigidBody.velocity = new Vector2(3f * speed * Input.GetAxis("Horizontal"), rigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //audioSource.clip = audioJump;
            audioSource.PlayOneShot(audioJump);

            if (jumpCount > 0)// && isPlay
            {
                jumpCount--;
                rigidBody.velocity = Vector2.up * speed * 5f;
                Instantiate(jump,gameObject.transform.position + jumpOffset, Quaternion.identity);
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

        if (collision.gameObject.layer.Equals(8) && collision.gameObject.tag.Equals("Finish"))
        {
            if (collision.gameObject.transform.position.y < gameObject.transform.position.y)
            {
                GameManagerScript.gameIsFinished = true;
                collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                onGround = true;
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(8) && !collision.gameObject.tag.Equals("Finish"))
        {
            onGround = false;

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
            onGround = true;
            getDamage = false;
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
        
    }

}
