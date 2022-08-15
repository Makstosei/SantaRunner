using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEventRaiser : MonoBehaviour
{
    [SerializeField] private GameEvent _OnStart;


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _OnStart.Raise();
        }
    }
}
