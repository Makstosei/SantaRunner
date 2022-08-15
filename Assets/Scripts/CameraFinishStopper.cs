using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFinishStopper : MonoBehaviour
{
    private GameObject _sleigh;
    [SerializeField] private CinemachineVirtualCamera _finishCamera;
    private bool _isFinishedAlready;
    [SerializeField] private GameEvent _finishGameEvent;

    private void OnEnable()
    {
        EventManager.onGameFinishEvent += Finish;
    }

    private void OnDisable()
    {
        EventManager.onGameFinishEvent -= Finish;
    }



    private void Awake()
    {
        _sleigh = FindObjectOfType<DeerStackController>()._santaSleigh.gameObject;
    }



    public void Finish()
    {
        if (!_isFinishedAlready)
        {
            _isFinishedAlready = true;
            this.transform.position = _sleigh.transform.position;
            _finishCamera.Follow = this.transform;
            _finishCamera.LookAt = this.transform;
        }
    }
}
