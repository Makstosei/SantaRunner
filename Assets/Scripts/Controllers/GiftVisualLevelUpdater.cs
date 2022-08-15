using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftVisualLevelUpdater : MonoBehaviour
{
    [SerializeField] private FloatSO _trunkCapasityFloatSO;
    [SerializeField] private List<GameObject> _SleighGiftList;
    [SerializeField] private int _currentLevel;
    [SerializeField] private int _target;
    [SerializeField] private GameObject _particleEffect;

    private void OnEnable()
    {
        EventManager.onUpdateTrunkSlider += UpdateGifts;
    }
    private void OnDisable()
    {
        EventManager.onUpdateTrunkSlider -= UpdateGifts;
    }

    private void Awake()
    {
        _currentLevel = 5;

    }
    public void UpdateGifts(float value)
    {
        var tempValue = value * _trunkCapasityFloatSO.Value;
        if (tempValue >= _trunkCapasityFloatSO.Value - .001)
        {
            _target = 4;
            SetActiveLoopList(_target);
        }
        else if (tempValue >= _trunkCapasityFloatSO.Value * 4 / 5 && value < _trunkCapasityFloatSO.Value-.001)
        {
            _target = 3;
            SetActiveLoopList(_target);
        }
        else if (tempValue >= _trunkCapasityFloatSO.Value * 3 / 5 && value < _trunkCapasityFloatSO.Value * 4 / 5)
        {
            _target = 2;
            SetActiveLoopList(_target);
        }
        else if (tempValue >= _trunkCapasityFloatSO.Value * 2 / 5 && value < _trunkCapasityFloatSO.Value * 3 / 5)
        {
            _target = 1;
            SetActiveLoopList(_target);
        }
        else if (tempValue >= _trunkCapasityFloatSO.Value * 1 / 5 && value < _trunkCapasityFloatSO.Value * 2 / 5)
        {
            _target = 0;
            SetActiveLoopList(_target);
        }
        else
        {
            AllHidden();
        }



    }

    private void SetActiveLoopList(int target)
    {
        for (int i = 0; i < _SleighGiftList.Count; i++)
        {
            if (i == target)
            {
                _SleighGiftList[i].SetActive(true);
                if (_target !=_currentLevel)
                {
                    Instantiate(_particleEffect, transform.position, gameObject.transform.rotation);
                    _currentLevel = _target;
                }     
            }
            else
            {
                _SleighGiftList[i].SetActive(false);
            }
        }
    }
    private void AllHidden()
    {
        for (int i = 0; i < _SleighGiftList.Count; i++)
        {
            _SleighGiftList[i].SetActive(false);
        }
    }

}
