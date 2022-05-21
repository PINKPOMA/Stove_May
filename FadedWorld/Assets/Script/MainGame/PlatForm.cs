using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatForm : MonoBehaviour
{
  public GameObject platformPrefab;
    public int count = 20;

    public float timeBetSpawnMin = 0.1f;
    private float timeBetSpawn;

    public float yMin = -2.5f;
    public float yMax = 1.5f; 
    private float xPos = 8f; 

    private GameObject[] platforms;
    private int currentIndex = 0;

    private Vector2 poolPosition = new Vector2(0, -25);
    private float lastSpawnTime;

    public GameObject plr;


    void Start() {
        platforms = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }

        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }

    void Update() {

        if(Time.time >= lastSpawnTime + timeBetSpawnMin)
        {
            lastSpawnTime = Time.time;


            float yPos = Random.Range(yMin, yMax);

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);
            xPos += 10;
            currentIndex++;

            if(currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }
}
