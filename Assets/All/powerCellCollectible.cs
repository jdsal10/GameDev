using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//hello

public class powerCellCollectible : MonoBehaviour
{
    //Call shooter object
    public NewBehaviourScript newBehaviourScript;

    public AudioClip collection; //collection sound
    

    // Update is called once per frame
    void Update()
    {
        //Rotate collectible
        transform.Rotate (new Vector3 (0, 30, 0) * Time.deltaTime);
        
    }

    //when trigger collision happens
    void OnTriggerEnter(Collider other)
    {
        //if the other object entering our trigger zone
        //play sound on collision
        AudioSource.PlayClipAtPoint(collection, transform.position);
        //has a tag called "Player"
        if (other.gameObject.CompareTag ("Player"))
        {
            newBehaviourScript.no_cell ++;
            gameObject.SetActive (false);
        }
    }
}
