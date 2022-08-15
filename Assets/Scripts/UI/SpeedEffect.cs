using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _speedEffectParticle;


    private void OnEnable()
    {
        EventManager.onGameFinishEvent += StopEffect;
    }

    private void OnDisable()
    {
        EventManager.onGameFinishEvent -= StopEffect;
    }



    public void StartEffect()
    {
        _speedEffectParticle.Play(true);
    }

    public void StopEffect()
    {
        _speedEffectParticle.gameObject.SetActive(false);

    }
}

