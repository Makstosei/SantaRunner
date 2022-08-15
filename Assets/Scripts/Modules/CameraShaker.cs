using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _followCamera;
    [SerializeField] private float _shakeTimer, _startIntensity;
    private float _shakeTimerTotal;
    private CinemachineBasicMultiChannelPerlin _followCameraMultiChannelPerlin;
    private bool _isShaking;
    private void Awake()
    {
        _followCameraMultiChannelPerlin = _followCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }
    void Update()
    {
        if (_shakeTimer > 0)
        {
            _isShaking = false;
            _shakeTimer -= Time.deltaTime;
            _followCameraMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(_startIntensity, 0f, 1 - (_shakeTimer / _shakeTimerTotal));
        }
    }


    public void ShakeCamera(float intensity, float time)
    {
        if (!_isShaking)
        {
            _isShaking = true;
            _followCameraMultiChannelPerlin.m_AmplitudeGain = intensity;
            _shakeTimer = time;
            _shakeTimerTotal = time;
            _startIntensity = intensity;
        }
        
    }


}
