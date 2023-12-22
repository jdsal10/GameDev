using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject firePrefab;
    public Transform[] spawnLocations;
    private int toSpawn = 2;
    private bool SpawnInitialized;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(!SpawnInitialized){
            SpawnFires();
            SpawnInitialized = true;
        } 
    }

    void SpawnFires()
    {
        //Initialise a list to store all the avaliable locations
        List<Transform> avaliableSpawnLocations = new List<Transform>(spawnLocations);
        //spawn the specified amount of fires
        for(int i = 0; i < toSpawn; i ++){
            //
            Transform randomSpawn = spawnLocations[Random.Range(0, spawnLocations.Length)];

            //choose location at random from avaliable list
            int randomIntex = Random.Range(0, avaliableSpawnLocations.Count);

            Instantiate(firePrefab, randomSpawn.position, randomSpawn.rotation);
        }
    }
}
