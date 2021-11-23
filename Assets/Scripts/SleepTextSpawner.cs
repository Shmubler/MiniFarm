using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepTextSpawner : MonoBehaviour
{
    public GameObject sleepTextObject;
    float randX;
    float randY;
    Vector2 whereToSpawn;

    private float xBounds = 8f;
    private float yBounds = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        int num = Random.Range(5, 8);
        for (int i = 0; i < num; i++) {
            randX = Random.Range(-xBounds, xBounds);
            randY = Random.Range(-yBounds, yBounds);
            whereToSpawn = new Vector2(randX, randY);
            Instantiate(sleepTextObject, whereToSpawn, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
