using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class painer : MonoBehaviour
{
    public GameObject[] obstacles;
    
    private void OnEnable() {
        
        for (int i = 0; i < obstacles.Length; i++)
        {
            if(Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    private void OnBecameInvisible()
    {
        if (transform.position.x < GameObject.Find("player").transform.position.x)
        {
            Destroy(gameObject);
        }
}
}
