using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrapTrigger : MonoBehaviour
{
    [SerializeField] private bool _isTriggered;
    private GameObject _sleigh;
    [SerializeField] private AudioClip _trapSound;
    [SerializeField] private GameObject _giftPopupEffect;
    [SerializeField] private GameObject _cloudPopupEffect;
    [SerializeField] private FloatSO _trunkScoreFloatSO;
    private CameraShaker _cameraShaker;
    [SerializeField] private float _time, _intensity;

    private void Awake()
    {
        _sleigh = FindObjectOfType<DeerStackController>()._santaSleigh.gameObject;
        _cameraShaker = FindObjectOfType<CameraShaker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Deer") || other.CompareTag("Player"))
        {
            if (!_isTriggered)
            {
                _isTriggered = true;

                if (_trunkScoreFloatSO.Value > 0)
                {
                    _trunkScoreFloatSO.SetNewAmount(0);
                    EventManager.Instance.UpdateTrunkSlider(_trunkScoreFloatSO.Value, _trapSound);
                    Instantiate(_giftPopupEffect, _sleigh.transform.position, _sleigh.transform.rotation);
                    Instantiate(_cloudPopupEffect, _sleigh.transform.position, _sleigh.transform.rotation);
                }
                else
                {
                    
                }
                _cameraShaker.ShakeCamera(_intensity, _time);
                EventManager.Instance.Vibrate();
                StartCoroutine(BlowEffect());
            }
            
        }
    }

    IEnumerator BlowEffect()
    {
        Instantiate(_cloudPopupEffect,this.transform.position, this.transform.rotation);
        this.transform.DOShakeScale(0.1f);
        yield return new WaitForSecondsRealtime(0.1f);
        this.transform.DOScale(Vector3.zero, 0.2f);
    }


}
