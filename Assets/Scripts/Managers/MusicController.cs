using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MusicController : MonoBehaviour
{
    [SerializeField] private SoundManagerSO _musicManagerSO;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameEvent _Finish;

    #region Singleton

    private static MusicController _instance;

    public static MusicController Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<MusicController>();
            return _instance;
        }
    }
    #endregion

    private void OnEnable()
    {
        EventManager.onSettingsOpen += OnSettingsOpened;
    }
    private void OnDisable()
    {
        EventManager.onSettingsOpen -= OnSettingsOpened;
    }

    private void Start()
    {
        _musicManagerSO.audioSource = _audioSource;
        _audioSource.volume = _musicManagerSO.volume;
        _audioSource.pitch = _musicManagerSO.pitch;
    }


    public void OnSettingsOpened(bool _value)
    {
        if (_value)
        {
            _musicManagerSO.audioSource.Pause();
        }
        else
        {
            if (_musicManagerSO.isSoundOn)
            {
                _musicManagerSO.audioSource.Play();
            }
        }
    }

    public void PlayMusic()
    {
        if (_musicManagerSO.isSoundOn)
        {
            _audioSource.Play();
            _audioSource.DOFade(0.1f, 1f);
        }
    }

    public void StopMusic(float soundFadeTime)
    {
        StartCoroutine(StopMusicRoutine(soundFadeTime));
    }

    public IEnumerator StopMusicRoutine(float soundFadeTime)
    {
        if (_musicManagerSO.isSoundOn)
        {
            _audioSource.DOFade(0, soundFadeTime);
            yield return new WaitForSeconds(soundFadeTime);
            _audioSource.Stop();
        }
    }

    public void ForNextLevelStop()
    {
        StartCoroutine(NextLevelRoutine(1));
    }
    public IEnumerator NextLevelRoutine(float soundFadeTime)
    {
        if (_musicManagerSO.isSoundOn)
        {
            _audioSource.DOFade(0, soundFadeTime);
            yield return new WaitForSeconds(soundFadeTime);
            _audioSource.Stop();
            _Finish.Raise();
        }
        else
        {
            yield return new WaitForSeconds(soundFadeTime);
            _Finish.Raise();
        }
    }
}


