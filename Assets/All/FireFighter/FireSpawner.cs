using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject firePrefab;
    public Transform[] spawnLocations;
    private int toSpawn = 2;
    private bool SpawnInitialized;

    //Store the generated 
    private List<GameObject> fireObjects = new List<GameObject>();

    // Start is called before the first frame update
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

    void SpawnFires()
    {
        // CHECK ON THIS
        // Clear the list when spawning new fires
        fireObjects.Clear();

        //Initialise a list to store all the avaliable locations
        List<Transform> avaliableSpawnLocations = new List<Transform>(spawnLocations);
        //spawn the specified amount of fires
        for(int i = 0; i < toSpawn; i ++){
            //Randomly choose an integer from avaliable list
            int randomIndex = Random.Range(0, avaliableSpawnLocations.Count);

            //select location using random number and instantiate the fire
            Transform randomSpawn = avaliableSpawnLocations[randomIndex];

            //Instantiate the fire objects
            // Instantiate(firePrefab, randomSpawn.position, randomSpawn.rotation);

            GameObject fireObject = Instantiate(firePrefab, randomSpawn.position, randomSpawn.rotation);

            fireObjects.Add(fireObject);

            //remove selected fire from teh list to avoid repetition of the location
            avaliableSpawnLocations.RemoveAt(randomIndex);
        }
        // Debug log to check if fire objects are spawned
        Debug.Log("Fire objects spawned: " + fireObjects.Count);
    }

    public List<GameObject> GetFireObjects()
    {
        Debug.Log("GetFireObjects is returning: " + fireObjects.Count);
        return fireObjects;
    }
}
