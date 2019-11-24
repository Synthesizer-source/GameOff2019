using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {


    public GameObject Player;
    public float smoothSpeed = 0.3f;
    private Vector3 currentVelocity;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void LateUpdate () {

        Vector3 newPos = new Vector3(transform.position.x, Player.transform.position.y, transform.position.z);
        

        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, smoothSpeed);


    }

}
