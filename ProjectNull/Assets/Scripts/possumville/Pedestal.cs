using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(ParticleSystem))]
public class Pedestal : MonoBehaviour
{
    public ParticleSystem PossumEffect
    {
        get
        {
            return GetComponentInChildren<ParticleSystem>();
        }
    }

    public void PlayParticleEffects()
    {
        PossumEffect.Play();
    }
}