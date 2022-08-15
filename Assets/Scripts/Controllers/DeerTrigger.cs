using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeerTrigger : MonoBehaviour
{
    [SerializeField] private bool _isCollected;
    [SerializeField] private AudioClip _collectSound;
    [SerializeField] private AudioClip _failCollectSound;
    [SerializeField] private GameObject _particleEffect;
    [SerializeField] private FloatSO _trunkCapacityFloatSO;
    [SerializeField] private FloatSO _trunkScoreFloatSO;
    [SerializeField] private float _increaseAmountOfTrunk;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Deer") || other.CompareTag("Player"))
        {
            if (!_isCollected)
            {
                _isCollected = true;
                EventManager.Instance.CollectNewDear(this.transform, _collectSound);
                Instantiate(_particleEffect, transform.position, gameObject.transform.rotation);
                EventManager.Instance.Vibrate();
                _trunkCapacityFloatSO.ChangeAmountBy((int)_increaseAmountOfTrunk);
                EventManager.Instance.UpdateTrunkSlider(_trunkScoreFloatSO.Value / _trunkCapacityFloatSO.Value, _collectSound);
            }
        }
    }


}
