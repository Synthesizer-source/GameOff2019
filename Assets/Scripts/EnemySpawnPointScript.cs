using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPointScript : MonoBehaviour {

    public Transform playerTransform;
    public float yOffset;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {

        Vector2 v = new Vector2(transform.position.x, playerTransform.transform.position.y + yOffset);
        transform.position = v;
        Physics2D.IgnoreLayerCollision(8, 10, true);
    }
}
