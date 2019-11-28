using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {


    public GameObject Player;
    public float smoothSpeed = 0.3f;
    Vector3 cameraPos;
    bool shake;


    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.35f;

    private Vector3 currentVelocity;
    // Use this for initialization
    void Start()
    {
        shake = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 newPos = new Vector3(transform.position.x, Player.transform.position.y, transform.position.z);
        cameraPos = newPos;
        if (shakeDuration > 0)
        {
            if (shake)
            {

                transform.position = new Vector3(0 + (Random.Range(-1f, 1f) * shakeAmount), newPos.y, newPos.z);

                shakeDuration -= Time.deltaTime;

            }

        }
        else
        {
            shakeDuration = 0f;
            shake = false;
            transform.position = cameraPos;
            transform.position = Vector3.SmoothDamp(transform.position, cameraPos, ref currentVelocity, smoothSpeed);

        }

        if (Player.transform.position.y > transform.position.y)
        {

            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, smoothSpeed);


        }



    }

    public void Shake()
    {
        if (!shake)
        {
            cameraPos = new Vector3(0, transform.position.y, transform.position.z);
            shake = true;

            shakeDuration = 0.35f;
        }

    }

}
