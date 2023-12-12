using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] private float amountExtingushedPerSecond = 1.0f;
    public GameObject waterHose; //link to fire hose object


    void Start()
    {
    }

    void Update()
    {
        //If F is pressed, shoot water
        if(Input.GetKey(KeyCode.F)){
            waterHose.SetActive(true);
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 100f) && hit.collider.TryGetComponent(out Fire fire))
             fire.TryExtinsguish(amountExtingushedPerSecond * Time.deltaTime);
        }else{
            //stop shooting water when f is not pressed
            waterHose.SetActive(false);
            // waterHoseParticles.Stop();
        }
    }
}
