using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private FloatSO _scoreFloatSO;
    [SerializeField] private FloatSO _GiftCountAtLevelFloatSO;
    [SerializeField] private FloatSO _trunkScoreFloatSO;
    [SerializeField] private FloatSO _trunkCapacityFloatSO;
    [SerializeField] private FloatSO _targetScore;
    [SerializeField] private FloatSO _bonusPointScore;


    public void CheckTargetScore()
    {
        float score = _scoreFloatSO.Value / _targetScore.Value;


        if (score == 0)
        {
            _bonusPointScore.SetNewAmount(0);
        }
        else if (score >= 1 && score < 1.2)
        {
            _bonusPointScore.SetNewAmount(1);
        }
        else if (score >= 1.2 && score < 1.4)
        {
            _bonusPointScore.SetNewAmount(2);
        }
        else if (score >= 1.4 && score < 1.6)
        {
            _bonusPointScore.SetNewAmount(3);
        }
        else if (score >= 1.6 && score < 1.8)
        {
            _bonusPointScore.SetNewAmount(4);
        }
        else if (score >= 1.8 && score < 2)
        {
            _bonusPointScore.SetNewAmount(5);
        }
        else if (score >= 2 && score < 2.2)
        {
            _bonusPointScore.SetNewAmount(6);
        }
        else if (score >= 2.2 && score < 2.4)
        {
            _bonusPointScore.SetNewAmount(7);
        }
        else if (score >= 2.6)
        {
            _bonusPointScore.SetNewAmount(8);
        }

    }

    public void FinishlineScoreCheck()
    {
        _scoreFloatSO.ChangeAmountBy(_trunkScoreFloatSO.Value);
        _trunkScoreFloatSO.SetNewAmount(0);
        EventManager.Instance.UpdateScore();
        EventManager.Instance.UpdateTrunkSlider(_trunkScoreFloatSO.Value, null);

        if (_scoreFloatSO.Value >= _targetScore.Value)
        {
            GameManager.Instance.LevelPassed();
            CheckTargetScore();
        }
        else
        {
            GameManager.Instance.LevelFailed();
            _bonusPointScore.SetNewAmount(0);
        }
    }





}
