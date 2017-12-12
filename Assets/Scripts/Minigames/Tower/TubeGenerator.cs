using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeGenerator : MonoBehaviour
{
   // public List<GameObject> platformPrefab;
    public GameObject platformPrefab;

    public int numberOfPlatforms;
    public float levelWidth;
    public float minY;
    public float maxY;

    // Use this for initialization
    void Start()
    {
       /* Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }*/

    }

    // Update is called once per frame
    void Update()
    {

    }
}
