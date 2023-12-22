using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    List<GameObject> radarObjects;
    public GameObject radarPrefab;
    List<GameObject> borderObjects;
    public float switchDistance;
    public Transform helpTransform;
    
    public FireSpawner fireSpawner;
    List<GameObject> fireObjects;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the value from GetFireObjects to the class-level fireObjects
        fireObjects = fireSpawner.GetFireObjects();

        Debug.Log("Fire objects received: " + (fireObjects != null));
        createRadarObjects();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < radarObjects.Count; i++){
            if(Vector3.Distance(radarObjects[i].transform.position, transform.position) > switchDistance){
                //switch to the border objects
                helpTransform.LookAt(radarObjects[i].transform);
                //determine correct position for the border object
                borderObjects[i].transform.position = transform.position + switchDistance*helpTransform.forward;
                borderObjects[i].layer = LayerMask.NameToLayer("Radar");
                radarObjects[i].layer = LayerMask.NameToLayer("Invisible");
            }else{
                //switch back to the radar objects
                borderObjects[i].layer = LayerMask.NameToLayer("Invisible");
                radarObjects[i].layer = LayerMask.NameToLayer("Radar");

            }
        }
    }
    void createRadarObjects()
    {
        radarObjects = new List<GameObject>();
        borderObjects = new List<GameObject>();

        // Debug.Log(fireObjects.Count);

        if (fireObjects != null && fireObjects.Count > 0)
        {
        foreach(GameObject o in fireObjects){
            //instantiate on radar objects
            Debug.Log(o);
            GameObject k = Instantiate(radarPrefab, o.transform.position, Quaternion.identity) as GameObject;
            radarObjects.Add(k);
            //Instantiate border objects
            GameObject j = Instantiate(radarPrefab, o.transform.position, Quaternion.identity) as GameObject;
            borderObjects.Add(j);
        }
        }
        else
        {
            Debug.Log("No fire objects obtained from FireSpawner");
        }
    }
}
