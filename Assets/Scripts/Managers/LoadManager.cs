using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{

    [SerializeField] private FloatSO _levelNo;
    public Slider progressBar; //Gösterge

    private IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        if (_levelNo.Value <= 4)
        {
            int temp = (int)_levelNo.Value;
            StartCoroutine(startLoading(temp));
        }
        else
        {
            var temp = _levelNo.Value % 4;
            if (temp == 0)
            {
                StartCoroutine(startLoading(4));
            }
            else if(temp == 1)
            {
                StartCoroutine(startLoading(1));
            }
            else if (temp == 2)
            {
                StartCoroutine(startLoading(2));
            }
            else if (temp == 3)
            {
                StartCoroutine(startLoading(3));
            }
        }

    }

    IEnumerator startLoading(int level)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        AsyncOperation async = SceneManager.LoadSceneAsync(level);

        while (!async.isDone)
        {
            progressBar.value = async.progress;
            yield return null;
        }

    }



}