using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class Camera_Update : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _followCamera;
    [SerializeField] private CinemachineVirtualCamera _finishCamera;
    [SerializeField] private CinemachineVirtualCamera _startCamera;
    [SerializeField] private CinemachineBrain _cinemachineBrainMainCam;

    private Cinemachine.CinemachineTransposer TransposerRef;
    private Cinemachine.CinemachineComposer ComposerRef;
    private object _deerListCount;


    public void OnEnable()
    {
        EventManager.SetCameraPosition += UpdateCameraPosition;
    }
    public void OnDisable()
    {
        EventManager.SetCameraPosition -= UpdateCameraPosition;
    }


    private void Awake()
    {
        _startCamera.m_Priority = 10;
        _followCamera.m_Priority = 9;
        _finishCamera.m_Priority = 8;
        TransposerRef = _followCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineTransposer>();
        ComposerRef = _followCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineComposer>();
        _deerListCount = 5;
        UpdateCameraPosition(5);
    }
    private IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        _startCamera.m_Priority = 8;

    }
    private void UpdateCameraPosition(int count)
    {
        StartCoroutine(SmoothCameraPositionUpdate(count));
    }

    IEnumerator SmoothCameraPositionUpdate(int count)
    {
        float targetfloat = -3 - count * 3f;
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.01f);

            if (TransposerRef.m_FollowOffset.z - 0.1 > targetfloat)
            {
                TransposerRef.m_FollowOffset.z -= 0.05f;
            }
            else if (TransposerRef.m_FollowOffset.z + 0.1f < targetfloat)
            {
                TransposerRef.m_FollowOffset.z += 0.05f;
            }
            else
            {
                break;
            }

        }
    }



    public void FinishLineTrigger()
    {
        StartCoroutine(FinishlineRoutine());
    }

    IEnumerator FinishlineRoutine()
    {
        yield return new WaitForSecondsRealtime(1f);
        _finishCamera.m_Priority = 11;
    }

    void AgainFollowPlayer()
    {
        _followCamera.Priority = 100;
    }

}
