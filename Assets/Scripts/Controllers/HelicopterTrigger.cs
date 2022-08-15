using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterTrigger : MonoBehaviour
{
    private bool _isCollected;
    [SerializeField] private PathCreation.Examples.PathFollower _pathFollower;


    private void OnTriggerEnter(Collider other)
    {
        if (!_isCollected)
        {
            if (other.CompareTag("Player"))
            {
                _isCollected = true;
                _pathFollower.speed = 30;

            }
        }
    }
}
