using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //Only allow fire range to be between 0 and 1
    [SerializeField, Range(0f,1f)] private float currentIntensity = 1.0f;
    private float [] startIntensities = new float[0];

    [SerializeField] private ParticleSystem [] fireParticleSystems = new ParticleSystem[0];

    private void Start()
    {
        startIntensities = new float[fireParticleSystems.Length];

        for(int i = 0; i < fireParticleSystems.Length; i++)
        {
            startIntensities[i] = fireParticleSystems[i].emission.rateOverTime.constant;
        }
        //On start start intensity equls whatever it is set on unity
    }

    private void Update()
    {
        ChangeIntensity();
    }

    private void ChangeIntensity()
    {
        for(int i = 0; i < fireParticleSystems.Length; i++)
        {
            //This is to modify the emission
            var emission = fireParticleSystems[i].emission;
            emission.rateOverTime = currentIntensity * startIntensities[i];
        }
    }
}
