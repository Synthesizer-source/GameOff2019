using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManagerScript : MonoBehaviour {

    public List<GameObject> platforms;
    public GameObject finishPlatform;

    public float numberOfPlatforms;
    public float levelWidth = 8f;
    public float minY = 3f;
    public float maxY = 5f;
    // Use this for initialization
    void Start () {

        Vector3 spawnPoint = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {

            spawnPoint.y += Random.Range(minY, maxY);
            spawnPoint.x = Random.Range(-levelWidth, levelWidth);
            int index = Random.Range(0, 10);
            
            if (i == numberOfPlatforms-1)
            {
                spawnPoint.x = 0;
                finishPlatform.transform.position = spawnPoint;
                
            }
            else
            {
                if (index < 8)
                {
                    Instantiate(platforms[0], spawnPoint, platforms[0].transform.rotation);
                }
                else if (index.Equals(8))
                {
                    Instantiate(platforms[1], spawnPoint, platforms[1].transform.rotation);
                }
                else
                {
                    spawnPoint.x = 0;
                    Instantiate(platforms[2], spawnPoint, platforms[2].transform.rotation);
                }

            }

        }

    }
	
}
