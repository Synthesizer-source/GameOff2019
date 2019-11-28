using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour {

    public GameObject player;
    public Vector2 offset;
    public GameObject bullet;
    public GameObject barrel;

    // Use this for initialization
    void Start()
    {
        transform.position = (Vector2)player.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 pos = player.transform.position + (Vector3)offset + Vector3.back * 5;
        //transform.position = (Vector2)player.transform.position + offset;
        transform.position = pos;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = mousePosition - transform.position;

        float t = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion a = Quaternion.Euler(0, 0, t);
        transform.localRotation = a;
        if (mousePosition.x < player.transform.position.x)
        {
            transform.localScale = new Vector3(1, -1, -5);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, -5);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Camera.main.GetComponent<CameraScript>().Shake();
            Fire();

        }


    }


    void Fire()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = mousePosition - transform.position;
        //direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion a = Quaternion.Euler(0, 0, angle - 90);
        Instantiate(bullet, barrel.transform.position, a);

        if (a.z > 0)
        {
            transform.localScale = new Vector3(1, -1, -5);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, -5);
        }




    }
}
