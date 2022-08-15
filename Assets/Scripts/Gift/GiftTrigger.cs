using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GiftTrigger : MonoBehaviour
{
    [SerializeField] private bool _isCollected;
    [SerializeField] private FloatSO _trunkScoreFloatSO;
    [SerializeField] private FloatSO _trunkCapacityFloatSO;
    [SerializeField] private FloatSO _GiftCountAtLevelFloatSO;
    [SerializeField] private GameObject _sleigh;
    [SerializeField] private List<AudioClip> _collectSound;
    [SerializeField] private AudioClip _failCollectSound;
    [SerializeField] private GameObject _particleEffect;

    private void Start()
    {
        _GiftCountAtLevelFloatSO.ChangeAmountBy(1);
        _sleigh = FindObjectOfType<DeerStackController>()._santaSleigh.gameObject;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!_isCollected)
        {
            _isCollected = true;
            if (other.CompareTag("Deer") || other.CompareTag("Player"))
            {
                if (_trunkScoreFloatSO.Value < _trunkCapacityFloatSO.Value)
                {
                    _trunkScoreFloatSO.ChangeAmountBy(1);
                    EventManager.Instance.UpdateTrunkSlider(_trunkScoreFloatSO.Value / _trunkCapacityFloatSO.Value, _collectSound[Random.Range(0,_collectSound.Count)]);
                    Instantiate(_particleEffect, transform.position, gameObject.transform.rotation);
                    this.transform.DOJump(_sleigh.transform.position, 3, 1, 0.3f);
                    this.transform.DOScale(.5f, 0.3f);
                    Destroy(gameObject, 0.3f);
                }
                else
                {
                    StartCoroutine(FailCollect());
                }

            }
        }
    }

    IEnumerator FailCollect()
    {
        this.transform.DOJump(this.transform.position, 2, 1, 0.3f);
        SoundManager.Instance.PlaySoundClip(_failCollectSound);
        this.transform.DOShakeScale(1, 2);
        EventManager.Instance.Vibrate();
        yield return new WaitForSecondsRealtime(0.2f);
        this.transform.DOScale(0.1f, 0.3f);
        Destroy(gameObject, 0.3f);
    }



}
