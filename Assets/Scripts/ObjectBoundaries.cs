using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBoundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    // Use this for initialization
    void Start()
    {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        objectWidth = GetComponent<SpriteRenderer>().bounds.extents.x / 2;
        

    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector2 viewPos = transform.position;

        viewPos.x = Mathf.Clamp(viewPos.x, (screenBounds.x * -1) + objectWidth, screenBounds.x - objectWidth);
        
        transform.position = viewPos;
    }
}
