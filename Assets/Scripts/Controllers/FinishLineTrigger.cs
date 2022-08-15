using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent _onFinishlineTrigger;
    private bool _isTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Deer") || other.CompareTag("Player"))
        {
            if (!_isTriggered)
            {
                _isTriggered = true;
                _onFinishlineTrigger.Raise();
            }
        }
    }
}
