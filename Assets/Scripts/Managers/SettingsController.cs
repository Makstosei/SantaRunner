using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsController : MonoBehaviour
{
    [SerializeField] private SoundManagerSO _soundManagerSO;
    [SerializeField] private SoundManagerSO _musicManagerSO;
    [SerializeField] private Image _soundOn, _soundOff, _musicOn, _musicOff, _vibrateOn, _vibrateOff;

    private void Start()
    {
        if (_soundManagerSO.isSoundOn)
        {
            _soundOn.enabled = true;
            _soundOff.enabled = false;
        }
        else
        {
            _soundOn.enabled = false;
            _soundOff.enabled = true;
        }
        if (_musicManagerSO.isSoundOn)
        {
            _musicOn.enabled = true;
            _musicOff.enabled = false;
        }
        else
        {
            _musicOn.enabled = false;
            _musicOff.enabled = true;
        }

        if (VibrationController.Instance.isVibraitonOn)
        {
            _vibrateOn.enabled = true;
            _vibrateOff.enabled = false;
        }
        else
        {
            _vibrateOn.enabled = false;
            _vibrateOff.enabled = true;

        }


       
    }



    public void OnSoundButtonPress()
    {
        if (!_soundManagerSO.isSoundOn)
        {
            _soundOn.enabled = true;
            _soundOff.enabled = false;
            _soundManagerSO.isSoundOn = true;
            PlayerPrefs.SetInt("sound", 1);
        }
        else
        {
            _soundOn.enabled = false;
            _soundOff.enabled = true;
            _soundManagerSO.isSoundOn = false;
            PlayerPrefs.SetInt("sound", 0);
        }
        Debug.Log(PlayerPrefs.GetInt("sound"));

    }

    public void OnMusicButtonPress()
    {
        if (!_musicManagerSO.isSoundOn)
        {
            _musicOn.enabled = true;
            _musicOff.enabled = false;
            _musicManagerSO.isSoundOn = true;
            PlayerPrefs.SetInt("music", 1);
        }
        else
        {
            _musicOn.enabled = false;
            _musicOff.enabled = true;
            _musicManagerSO.isSoundOn = false;
            PlayerPrefs.SetInt("music", 0);
        }
        Debug.Log(PlayerPrefs.GetInt("music"));

    }
    public void OnVibrationButtonPress()
    {
        if (!VibrationController.Instance.isVibraitonOn)
        {
            _vibrateOn.enabled = true;
            _vibrateOff.enabled = false;
            PlayerPrefs.SetInt("vibration", 1);
            VibrationController.Instance.isVibraitonOn = true;
         
        }
        else
        {
            _vibrateOn.enabled = false;
            _vibrateOff.enabled = true;
            PlayerPrefs.SetInt("vibration", 0);
            VibrationController.Instance.isVibraitonOn = false;
        }
        Debug.Log(PlayerPrefs.GetInt("vibration"));
    }
}
