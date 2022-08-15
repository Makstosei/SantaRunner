using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishBuildingTrigger : MonoBehaviour
{
    [SerializeField] private FloatSO _scoreFloatSO;
    [SerializeField] private FloatSO _GiftCountAtLevelFloatSO;
    [SerializeField] private FloatSO _bonusPointScore;
    [SerializeField] private AudioClip _dropSound;
    [SerializeField] private GameObject _particleEffect;
    [SerializeField] private bool _isTriggered;
    [SerializeField] GameObject _gift;
    [SerializeField] private Transform _giftDropPoint;
    [SerializeField] GameEvent _finishGameEvent;
    [SerializeField] private Material _glowMaterial;
    private Transform _sleighTransform;

    private void Awake()
    {
        _sleighTransform = FindObjectOfType<DeerStackController>()._santaSleigh.gameObject.transform.GetChild(0).transform;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_isTriggered)
            {
                _isTriggered = true;
                if (GameManager.Instance._isLevelPassed)
                {
                    if (_bonusPointScore.Value > 0)
                    {
                        StartCoroutine(DeployGiftRoutine());
                        this.transform.parent.GetChild(0).GetComponent<MeshRenderer>().material = _glowMaterial;
                        _bonusPointScore.ChangeAmountBy(-1);
                    }
                    if (_bonusPointScore.Value <= 0)
                    {
                        EventManager.Instance.GameFinish();
                    }
                }
                else
                {
                    EventManager.Instance.GameFinish();
                }
               
            }
        }
    }

    IEnumerator DeployGiftRoutine()
    {
        SoundManager.Instance.PlaySoundClip(_dropSound);
        DeployGift();
        yield return new WaitForSecondsRealtime(0.1f);
        DeployGift();
        yield return new WaitForSecondsRealtime(0.1f);
        DeployGift();
    }




    void DeployGift()
    {
        GameObject _tempGift = Instantiate(_gift, this.transform.parent);
        _tempGift.transform.position = _sleighTransform.position;
        _tempGift.transform.localScale = new Vector3(1, 1, 1);
        _tempGift.transform.DOJump(_giftDropPoint.position, 5, 1, 1f);
        Destroy(_tempGift, 2f);
    }
}
