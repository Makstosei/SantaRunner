using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationController : MonoBehaviour
{
    public bool isVibraitonOn;


    #region Singleton

    private static VibrationController _instance;
    public static VibrationController Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<VibrationController>();
            return _instance;
        }
    }
    #endregion

    private void OnEnable()
    {
        EventManager.onVibrate += VibrateEvent;
    }
    private void OnDisable()
    {
        EventManager.onVibrate -= VibrateEvent;

    }


    private void Start()
    {
        if (PlayerPrefs.HasKey("vibration"))
        {
            if (PlayerPrefs.GetInt("vibration") == 1)
            {
                isVibraitonOn = true;
                PlayerPrefs.SetInt("vibration", 1);
            }
            else
            {
                isVibraitonOn = false;
            }
        }
        else
        {
            PlayerPrefs.SetInt("vibration", 1);
            isVibraitonOn = true;
        }
    }

  
    void VibrateEvent()
    {
        if (isVibraitonOn)
        {
            NiceVibrationsManager.LightImpact();
        }
    }






}
