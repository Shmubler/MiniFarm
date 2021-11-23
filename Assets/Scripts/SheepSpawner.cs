using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour {
    public GameObject sheepObject;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    int numSpawns;
    public GameObject InputFieldText;

    // Start is called before the first frame update
    void Start() {
        numSpawns = Random.Range(5, 8);
        StartCoroutine(SpawnCoroutine(numSpawns));

        Debug.Log(numSpawns);
    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator SpawnCoroutine(int numSpawns) {
        for (int i = 0; i < numSpawns; i++) {
            int randTime = Random.Range(1, 3);
            whereToSpawn = new Vector2(-1, randY = Random.Range(0, 5));
            Instantiate(sheepObject, whereToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(randTime);
        }
        InputFieldText.GetComponent<Animator>().Play("SheepInputFieldAnimation");
    }

    public void ReadEntryText(string t) {
        int guess = int.Parse(t);
        if (guess == numSpawns) {
            Debug.Log("You win");
        }
        else {
            Debug.Log("You lose");
        }
    }

}
