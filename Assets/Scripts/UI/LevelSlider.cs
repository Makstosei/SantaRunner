using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using DG.Tweening;
[RequireComponent(typeof(Slider))]

public class LevelSlider : MonoBehaviour
{
    [SerializeField] private float _smoothTime = 0.5f;
    [SerializeField] private bool _isLevelSlider;
    [SerializeField] Slider _bar;

    private void OnEnable()
    {
        EventManager.onUpdateLevelSlider += SetBarValue;
    }
    private void OnDisable()
    {
        EventManager.onUpdateLevelSlider -= SetBarValue;
    }


    public void SetBarValue(float value)
    {
        _bar.DOValue(value, _smoothTime).SetEase(Ease.Linear);
    }
}