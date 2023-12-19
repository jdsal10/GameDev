using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CammeraFollows : MonoBehaviour
{
    public GameObject car;
    private Vector3 place;
    // Start is called before the first frame update
    void Start()
    {
        place = transform.position - car.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = car.transform.position + place;  
    }
}
