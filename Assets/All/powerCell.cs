using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//test2

public class powerCell : MonoBehaviour
{
    public GameObject explode;

    private GameObject tripod;
    float removeTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        tripod = GameObject.Find ("tripod");//find the tripod
        Destroy(gameObject, removeTime); //destory the object after 2s
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Enemy") {
            //instantiate the explosion
            Instantiate(explode, transform.position, transform.rotation);
            //reduce the tripod's health
            tripod.GetComponent<triPodHealth>().reduceHealth();
            Destroy(gameObject);//destory self
          }

        if(other.gameObject.tag == "Box"){
            //instantiate the explosion
            Instantiate(explode, transform.position, transform.rotation);
            Destroy(gameObject);//destory self
            Destroy(other.gameObject);
        }
     }

     void OnDestroy(){
        Instantiate(explode, transform.position, transform.rotation);
     }
 }
