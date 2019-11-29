using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour {

    public GameObject player;
    public Vector2 offset;
    public GameObject bullet;
    public GameObject barrel;
    public AudioClip audioShoutgun;
    public AudioClip audioReload;
    float duration;
    bool isReload;
    bool fireFree;
    // Use this for initialization
    void Start()
    {
        fireFree = true;
        isReload = false;
        duration = audioShoutgun.length;
        transform.position = (Vector2)player.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {

        if (!PauseMenuScript.gameIsPaused)
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
                if (fireFree)
                {
                    Camera.main.GetComponent<CameraScript>().Shake();
                    Fire();
                }


            }

            if (isReload)
            {

                if (duration <= 0)
                {
                    player.GetComponent<AudioSource>().PlayOneShot(audioReload);
                    fireFree = true;
                    duration = audioShoutgun.length;
                    isReload = false;

                }
                else
                {
                    duration -= Time.deltaTime;
                }



            }

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
        player.GetComponent<AudioSource>().PlayOneShot(audioShoutgun);
        
        Instantiate(bullet, barrel.transform.position, a);

        isReload = true;
        fireFree = false;
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
