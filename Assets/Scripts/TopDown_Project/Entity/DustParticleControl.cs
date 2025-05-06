using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleControl : MonoBehaviour
{
    [SerializeReference] private bool createDustOnWalk = true;
    [SerializeReference] private ParticleSystem dustParticleSystem;

    public void CreateDustParticles()
    {
        if (createDustOnWalk)
        {
            dustParticleSystem.Stop();
            dustParticleSystem.Play();
        }
    }
}
