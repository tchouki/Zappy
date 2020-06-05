using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_food : MonoBehaviour
{
    public GameObject[] spawnees;
    int randomInt;
    int randomX;
    int randomZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRandom()
    {
        randomInt = Random.Range(0, spawnees.Length);
        randomX = Random.Range(-5, 4);
        randomZ = Random.Range(-5, 4);
        Instantiate(spawnees[randomInt], new Vector3(randomX, 0.5f, randomZ), Quaternion.Euler(new Vector3(0,0,0)));
    }
}
