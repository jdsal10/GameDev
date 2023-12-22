using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    //variables for the fire
    public GameObject firePrefab;
    public Transform[] spawnLocations;
    //Amount of fires to spawn
    private int toSpawn = 6;
    private bool SpawnInitialized;

    //Store the generated fireobjects
    private List<GameObject> fireObjects = new List<GameObject>();

    // Spawn fires when it has not been intialized to avoid duplication
    void Start()
    {
        if(!SpawnInitialized){
            SpawnFires();
            SpawnInitialized = true;
        } 
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    //This method is in charge of spawing the fire objects and store them on a list
    void SpawnFires()
    {
        // CHECK ON THIS
        // Clear the list when spawning new fires
        fireObjects.Clear();

        //Initialise a list to store all the avaliable locations where the fires could appear
        List<Transform> avaliableSpawnLocations = new List<Transform>(spawnLocations);
        //spawn the specified amount of fires
        for(int i = 0; i < toSpawn; i ++){
            //Randomly choose an integer from size of the list
            int randomIndex = Random.Range(0, avaliableSpawnLocations.Count);

            //select location using random number and instantiate the fire
            Transform randomSpawn = avaliableSpawnLocations[randomIndex];

            //Instantiate the fire objects
            GameObject fireObject = Instantiate(firePrefab, randomSpawn.position, randomSpawn.rotation);

            //add the instantiated object to the list
            fireObjects.Add(fireObject);

            //remove selected fire from teh list to avoid repetition of the location
            avaliableSpawnLocations.RemoveAt(randomIndex);
        }
        // Debug log to check if fire objects are spawned
        Debug.Log("Fire objects spawned: " + fireObjects.Count);
    }

    //method to obtain stored list of fire objects
    public List<GameObject> GetFireObjects()
    {
        Debug.Log("GetFireObjects is returning: " + fireObjects.Count);
        return fireObjects;
    }
}
