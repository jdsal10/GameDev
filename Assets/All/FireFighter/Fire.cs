using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //Only allows the fire intensity to be between 0 and 1
    [SerializeField, Range(0f,1f)] private float currentIntensity = 1.0f;
    //Array to store all the intensity values
    private float [] startIntensities = new float [0];

    //Array of particle systems to be able to adjust all of the fire particle systems at the same time
    [SerializeField] private ParticleSystem [] fireParticleSystems = new ParticleSystem[0];

    //Store last watered time and intialize generation variables
    float timeLastWatered = 0;
    [SerializeField] private float regenDelay = 2.5f;
    [SerializeField] private float regenRate = .1f;

    public bool isLit = true;
    private bool isEmssionZero = false;

    public GameObject steam;

    private void Start()
    {
        //intiliase array to store fire particles system
        startIntensities = new float[fireParticleSystems.Length];

        //populate array with the current emission rate of each particle
        for(int i = 0; i < fireParticleSystems.Length; i++)
        {
            startIntensities[i] = fireParticleSystems[i].emission.rateOverTime.constant;
        }
        steam = transform.GetChild(3).gameObject;
    }

    private void Update()
    {
        // If the fire is being extinsguhed and egeneration delay has passed. Start regeneration
        if(isLit && currentIntensity < 1.0f && Time.time - timeLastWatered >= regenDelay)
        {
            currentIntensity += regenRate * Time.deltaTime;
            ChangeIntensity();
        }
    }

    //Method used to extinguish fire
    public bool TryExtinsguish(float toReduce)
    {
        //Store time of extingushing 
        timeLastWatered = Time.time;
        //Recude the current intensity by the set amount
        currentIntensity -= toReduce;

        //Check if fire was extingushed
        if(isEmssionZero)
        {
            isLit = false;
            return true;
        }

        ChangeIntensity();

        //fire is still lit
        return false; 
    }

    private void ChangeIntensity()
    {
        //loop over fire particle systems and adjust the rate Over time based on the current intensity
        for(int i = 0; i < fireParticleSystems.Length; i++)
        {
            var emission = fireParticleSystems[i].emission;
            emission.rateOverTime = currentIntensity * startIntensities[i];
            //check if fire has been extenguished 
            if(emission.rateOverTime.constant == 0)
            {
                isEmssionZero = true;
            }
        }  
    }

}
