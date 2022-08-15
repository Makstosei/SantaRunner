using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject _startGameUi;
    [SerializeField] private GameObject _levelUi;
    [SerializeField] private GameObject _nextLevelUi;
    [SerializeField] private GameObject _restartLevelUi;
    [SerializeField] private GameObject _settingUi;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private SoundManagerSO _soundManagerSO;
    [SerializeField] private SoundManagerSO _musicManagerSO;
    [SerializeField] private FloatSO _levelNo;
    [SerializeField] private FloatSO _scoreFloatSO;
    [SerializeField] private FloatSO _targetScoreFloatSO;


    private void OnEnable()
    {
        EventManager.onChangeScore += UpdateScoreText;
        EventManager.onGameFinishEvent += CheckAndOpenNext;
    }

    private void OnDisable()
    {
        EventManager.onChangeScore -= UpdateScoreText;
        EventManager.onGameFinishEvent -= CheckAndOpenNext;
    }


    private void Start()
    {
        _levelText.text = "Level " + _levelNo.Value.ToString();
        UpdateScoreText();
    }
    public void OpenInGameLevelUi()
    {
        _startGameUi.SetActive(false);
        _levelUi.SetActive(true);

    }
    public void CloseLevelUi()
    {
        _levelUi.SetActive(false);

    }
    public void UpdateScoreText()
    {
        _scoreText.text = _scoreFloatSO.Value.ToString()+"/"+_targetScoreFloatSO.Value;
    }
    public void OpenNextLevelUI()
    {
        _nextLevelUi.SetActive(true);
    }

    public void CheckAndOpenNext()
    {
        if (GameManager.Instance._isLevelPassed)
        {
            _nextLevelUi.SetActive(true);
        }

    }

    public void CheckAndOpenRestart()
    {
        StartCoroutine(CheckAndOpenRestartRoutine());
    }
    IEnumerator CheckAndOpenRestartRoutine()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        if (!GameManager.Instance._isLevelPassed)
        {
            _restartLevelUi.SetActive(true);
        }
    }
    public void CloseSettingsUI()
    {
        Time.timeScale = 1;
        _settingUi.SetActive(false);
        _levelUi.SetActive(true);
        EventManager.Instance.SettingsOpened(false);
    }

    public void OpenSettingUI()
    {
        _levelUi.SetActive(false);
        _settingUi.SetActive(true);
        Time.timeScale = 0;
        EventManager.Instance.SettingsOpened(true);

    }

    public void OpenRestartLevel()
    {
        StartCoroutine(WaitForOpenRestartUi());
    }


    IEnumerator WaitForOpenRestartUi()
    {
        yield return new WaitForSecondsRealtime(1f);
        _restartLevelUi.SetActive(true);
    }

}
