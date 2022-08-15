using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections.Generic;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }
    #endregion

    #region Actions
    public static Action InGameEvent;
    public static Action EndGameEvent;
    public static Action<int> ScoreBoardEvent;
    public static Action<int> ScoreUpdate;
    #endregion

    [SerializeField] private FloatSO _levelNo;
    [SerializeField] private FloatSO _scoreFloatSO;
    [SerializeField] private List<Scene> Levels;
    [SerializeField] AudioClip _levelPassedSound, _levelFailedSound;
    private bool _isClicked; // Next level Button Double Click Control
    public bool _isLevelPassed;
    [SerializeField] private int _updateCheck = 2;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("updateCheck"))
        {
            if (PlayerPrefs.GetInt("updateCheck")!=_updateCheck)
            {
                PlayerPrefs.DeleteAll();
                PlayerPrefs.SetInt("updateCheck", _updateCheck);
            }
        }
        else
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("updateCheck", _updateCheck);
        }
        System.GC.Collect();
        Resources.UnloadUnusedAssets();
        Initial();
    }

    private void Initial()
    {
        Application.targetFrameRate = 60;

        _isClicked = false;
    }

    public void StartEvent()
    {
    }


    public void NextLevel()
    {
        if (!_isClicked)
        {
            _levelNo.ChangeAmountBy(1);
            _isClicked = true;
            PlayerPrefs.SetInt("level", (int)_levelNo.Value);
            StartCoroutine(GoNextlevel(0, 0));
        }
    }

    IEnumerator GoNextlevel(float waitTime, int level)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        //if (SceneManager.GetActiveScene().buildIndex >= 3)
        //{
        //    SceneManager.LoadScene(0, LoadSceneMode.Single);
        //}
        //else
        //{
        //    DOTween.Clear();
        //    DOTween.ClearCachedTweens();
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        //}

    }
    public void RestartLevel()
    {

        if (!_isClicked)
        {
            _isClicked = true;
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }
    }

    public void LevelPassed()
    {
        _isLevelPassed = true;
        SoundManager.Instance.PlaySoundClip(_levelPassedSound);
    }
    public void LevelFailed()
    {
        _isLevelPassed = false;
        SoundManager.Instance.PlaySoundClip(_levelFailedSound);
    }

}
