using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour {

    public float spawnHeight;
    public float spawnTime;
    public GameObject[] spawnPoints;
    public GameObject[] enemies;
    public GameObject player;

    float timer;

    // Use this for initialization
    void Start()
    {

        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position.Set(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        if (player.transform.position.y > spawnHeight)
        {
            if (timer >= spawnTime)
            {
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                int enemyIndex = Random.Range(0, enemies.Length);

                Instantiate(enemies[enemyIndex], spawnPoints[spawnPointIndex].transform.position, Quaternion.identity);

                timer = 0.0f;
            }
            else
            {
                timer += Time.deltaTime;
            }


        }

    }
}
