using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EventManager : MonoBehaviour
{
    #region Singleton

    private static EventManager _instance;

    public static EventManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<EventManager>();
            return _instance;
        }
    }
    #endregion

    [Serializable] public class gameEvents : UnityEvent { }
    public gameEvents Trap;
    public gameEvents onGameStart;
    public gameEvents onGameFinish;
    public static Action onGameFinishEvent;
    public static Action<float> onUpdateTrunkSlider;
    public static Action<float> onUpdateLevelSlider;
    public static Action<Transform> onCollectNewDear;
    public static Action<int> SetCameraPosition;
    public static Action<bool> onSettingsOpen;
    public static Action onVibrate;
    public static Action onChangeScore;

    public void SettingsOpened(bool _value)
    {
        onSettingsOpen.Invoke(_value);
    }

    public void Trapped(AudioClip _audioClip)
    {
        Trap.Invoke();
        SoundManager.Instance.PlaySoundClip(_audioClip);

    }

    public void GameStart()
    {
        onGameStart.Invoke();
    }

    public void GameFinish()
    {
        onGameFinish.Invoke();
        onGameFinishEvent.Invoke();
    }

    public void UpdateTrunkSlider(float _value,AudioClip _audioClip)
    {
        onUpdateTrunkSlider.Invoke(_value);
        SoundManager.Instance.PlaySoundClip(_audioClip);
    }
    public void UpdateLevelSlider(float _value, AudioClip _audioClip)
    {
        onUpdateLevelSlider.Invoke(_value);
        SoundManager.Instance.PlaySoundClip(_audioClip);
    }
    public void CollectNewDear(Transform _transform,AudioClip _audioClip)
    {
        onCollectNewDear.Invoke(_transform);
        SoundManager.Instance.PlaySoundClip(_audioClip);
    }

    public void onSetCameraPosition(int _count)
    {
        SetCameraPosition.Invoke(_count);
    }

    public void UpdateScore()
    {
        onChangeScore.Invoke();
    }

    public void Vibrate()
    {
        onVibrate.Invoke();
    }


}
