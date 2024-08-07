using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] private float amountExtingushedPerSecond = 1.0f;
    public GameObject waterHose; //link to fire hose object
    [SerializeField] private float arcHeight = 1.0f; //adjust height of the arc, test
    private GameObject Steam;


    void Start()
    {
    }

    void Update()
    {
       
        //If F is pressed, shoot water
        if(Input.GetKey(KeyCode.F)){
            waterHose.SetActive(true);

            //calculate the cureved direction of the arc
            Vector3 curvedDirection = CalculateCurvedDirection(Camera.main.transform.forward);
            Debug.DrawLine(Camera.main.transform.position, curvedDirection, Color.red);

            //use raycasting to extinguish fire
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 100f) && hit.collider.TryGetComponent(out Fire fire))
            {
                fire.TryExtinsguish(amountExtingushedPerSecond * Time.deltaTime);
                Steam = fire.steam;
                if(fire.isLit){
                    Steam.SetActive(true);
                } else{
                    Steam.SetActive(false);
                }
            }
             
             
            // if(Physics.Raycast(Camera.main.transform.position, curvedDirection, out RaycastHit hit, 100f) && hit.collider.TryGetComponent(out Fire fire))
            //  fire.TryExtinsguish(amountExtingushedPerSecond * Time.deltaTime);
        }else{
            //stop shooting water when f is not pressed
            waterHose.SetActive(false);
        }
    }

    //calculate the curve to have an arched line when detecting teh fire
    private Vector3 CalculateCurvedDirection(Vector3 initialDirection)
    {
        Vector3 curvedDirection = initialDirection + Vector3.up * arcHeight;

        return curvedDirection.normalized;
    }
}
