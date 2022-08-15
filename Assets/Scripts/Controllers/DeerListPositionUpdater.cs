using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerListPositionUpdater : MonoBehaviour
{
    [SerializeField] private GameObject _pathFollowerRef;

    void Update()
    {
        this.transform.forward = _pathFollowerRef.transform.forward;
        gameObject.transform.position = _pathFollowerRef.transform.position;
    }
}
