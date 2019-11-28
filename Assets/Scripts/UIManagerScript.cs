using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {

    public Text currentScore;
    public Text maxScore;
    public Text killScore;
    GameObject player;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        
	}
	
	// Update is called once per frame
	void Update () {

        currentScore.text = player.GetComponent<PlayerScript>().CurrentHeight.ToString();
        maxScore.text = "MAX : " + player.GetComponent<PlayerScript>().maxHeight.ToString();
        killScore.text = "KILL : " + player.GetComponent<PlayerScript>().Kill;

    }
}
