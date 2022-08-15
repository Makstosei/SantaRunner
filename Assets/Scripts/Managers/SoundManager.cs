using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundManagerSO _soundManagerSO;
    [SerializeField] private AudioSource _audioSource;
    private bool _winplayed, _ismuted;

    #region Singleton

    private static SoundManager _instance;

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<SoundManager>();
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
        _soundManagerSO.audioSource = _audioSource;
        _audioSource.volume = _soundManagerSO.volume;
        _audioSource.pitch = _soundManagerSO.pitch;

        if (!PlayerPrefs.HasKey("muted")) PlayerPrefs.SetInt("muted", 0);

        LoadSoundSettings();
    }

    public void OnSettingsOpened(bool _value)
    {
        if (_value)
        {
            _soundManagerSO.audioSource.Pause();
        }
        else
        {
            if (_soundManagerSO.isSoundOn)
            {
                _soundManagerSO.audioSource.Play();
            }
        }
    }
   



    void SaveSoundSettings()
    {
        if (_ismuted)
        {
            PlayerPrefs.SetInt("muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("muted", 0);
        }
    }

    void LoadSoundSettings()
    {
        if (PlayerPrefs.GetInt("muted") == 1)
        {
            _ismuted = true;
            AudioListener.pause = true;
        }
        else
        {
            _ismuted = false;
            AudioListener.pause = false;
        }
    }

    public void PlaySoundClip(AudioClip _audioClip)
    {
        if (_soundManagerSO.isSoundOn)
        {
            _soundManagerSO.audioSource.PlayOneShot(_audioClip);
        }
    }
    public void PlaySoundClip(AudioClip _audioClip, float _audioVolume)
    {
        if (_soundManagerSO.isSoundOn)
        {
            _soundManagerSO.volume = _audioVolume;
            _soundManagerSO.audioSource.PlayOneShot(_audioClip);
        }
    }
    public void PlaySoundClip(AudioClip _audioClip, float _audioVolume, float _audioPitch)
    {
        if (_soundManagerSO.isSoundOn)
        {
            _soundManagerSO.volume = _audioVolume;
            _soundManagerSO.pitch = _audioPitch;
            _soundManagerSO.audioSource.PlayOneShot(_audioClip);
        }
    }

}