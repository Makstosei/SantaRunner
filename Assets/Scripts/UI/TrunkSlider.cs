using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

[RequireComponent(typeof(Slider))]

public class TrunkSlider : MonoBehaviour
{
    [SerializeField] private float _smoothTime = 0.5f;
    [SerializeField] private bool _isLevelSlider;
    [SerializeField] Slider _bar;

    private void OnEnable()
    {
        EventManager.onUpdateTrunkSlider += SetBarValue;
    }
    private void OnDisable()
    {
        EventManager.onUpdateTrunkSlider -= SetBarValue;
    }

    private void Start()
    {
        _bar.transform.localScale = new Vector3(0.5f,0.3f,0.5f);
    }

    public void SetBarValue(float value)
    {
        _bar.transform.DOShakeScale(0.5f, 0.5f);
        _bar.DOValue(value, _smoothTime).SetEase(Ease.Linear);
    }
}