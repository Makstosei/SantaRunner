using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkDischargeTrigger : MonoBehaviour
{
    [SerializeField] private bool _isCollected;
    [SerializeField] private FloatSO _scoreFloatSO;
    [SerializeField] private FloatSO _trunkScoreFloatSO;
    [SerializeField] private FloatSO _trunkCapacityFloatSO;
    [SerializeField] private FloatSO _giftCountAtLevel;
    [SerializeField] private AudioClip _dischargeSound;
    [SerializeField] private GameObject _particleEffect;
    [SerializeField] private GameObject _sleigh;

    private void Start()
    {
        _sleigh = FindObjectOfType<DeerStackController>()._santaSleigh.gameObject;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_isCollected)
            {
                _isCollected = true;
                if (_trunkScoreFloatSO.Value > 0)
                {
                    _scoreFloatSO.ChangeAmountBy(_trunkScoreFloatSO.Value);
                    _trunkScoreFloatSO.SetNewAmount(0);
                    EventManager.Instance.UpdateScore();
                    EventManager.Instance.UpdateTrunkSlider(_trunkScoreFloatSO.Value, _dischargeSound);
                    Instantiate(_particleEffect, _sleigh.transform.position, gameObject.transform.rotation);
                }
            }
        }
    }

}
