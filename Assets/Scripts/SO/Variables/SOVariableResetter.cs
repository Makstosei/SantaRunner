using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SOVariableResetter : MonoBehaviour
{
    [SerializeField] private List<FloatSO> FloatSOList;
    [SerializeField]  private FloatSO _level;
    [SerializeField] private FloatSO _targetScoreSO;
    [SerializeField] private float _targetValue;
    [SerializeField] SoundManagerSO _music;
    [SerializeField] SoundManagerSO _sound;

    private void Awake()
    {
        _targetScoreSO.SetNewAmount(_targetValue);
        LoadSettings();
        LoadLevel();
        for (int i = 0; i < FloatSOList.Count; i++)
        {
            FloatSOList[i].ResetValue();
        }  
    }

    public void LoadLevel()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            if (PlayerPrefs.GetInt("level")==0)
            {
                _level.SetInitialValue(1);
                PlayerPrefs.SetInt("level", 1);

            }
            else
            {
                _level.SetInitialValue(PlayerPrefs.GetInt("level"));
            }        
        }
        else
        {
            _level.SetInitialValue(1);
            PlayerPrefs.SetInt("level", 1);
        }
    }
    public void NextLevel()
    {
        StartCoroutine(NextRoutine());
    }
    public void SaveLevel()
    {
        PlayerPrefs.SetInt("level",(int) _level.Value);
    }
    IEnumerator NextRoutine()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        if (GameManager.Instance._isLevelPassed)
        {
            PlayerPrefs.SetInt("level",(int) _level.Value+1);
        }
        else
        {
            PlayerPrefs.SetInt("level", (int)_level.Value);
        }    
    }
    void LoadSettings()
    {
        if (PlayerPrefs.HasKey("music"))
        {
            if (PlayerPrefs.GetInt("music") == 1)
            {
                _music.isSoundOn = true;
            }
            else
            {
                _music.isSoundOn = false;
            }

        }
        else
        {
            _music.isSoundOn = false;
            PlayerPrefs.SetInt("music", 0);
        }

        if (PlayerPrefs.HasKey("sound"))
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                _sound.isSoundOn = true;
            }
            else
            {
                _sound.isSoundOn = false;
            }

        }
        else
        {
            _sound.isSoundOn = true;
            PlayerPrefs.SetInt("sound", 1);
        }
    }
}
