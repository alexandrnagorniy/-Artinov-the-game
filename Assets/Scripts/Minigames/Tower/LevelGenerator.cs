using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public GameObject platformPrefab, tubePrefab;
    public Transform player;
    public int numberOfPlatforms;
    public float levelWidth;
    public float minY;
    public float maxY;
    private int next = -3;
    // Use this for initialization
    void Start () {
        for (int i = -3; i < 7; i+=2)
        {
            Spawn((float)i);

        }
        /*Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            int rand = Random.Range(0, 50);
            if (rand >= 30)
            {
                Instantiate(tubePrefab, spawnPosition, Quaternion.identity);
            }
        }*/

    }
	
	// Update is called once per frame
	void Update () {
        /*if (player != null)
        {
            if (player.position.y > transform.position.y - 3)
                transform.position = new Vector3(0, player.position.y + 3, -10);
        }
        else*/
            
        if (Vector2.Distance(transform.position, new Vector2(0, next)) < 7)
            Spawn(next);
    }
    void Spawn(float y)
    {
        int random = Random.Range(-4, 4);
        Instantiate(platformPrefab, new Vector2(random, y), Quaternion.identity);
        int rand = Random.Range(0, 50);
        if (rand >= 30)
        {
            Instantiate(tubePrefab, new Vector2(random, y+1), Quaternion.identity);
        }
        next+=2;
    }
}
