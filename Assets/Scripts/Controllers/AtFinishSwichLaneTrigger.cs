using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtFinishSwichLaneTrigger : MonoBehaviour
{
    [SerializeField] private PathCreation.PathCreator _loopPath;
    [SerializeField] private PathCreation.Examples.PathFollower _follower;
    private bool isEnabled;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Deer") )
        {
            if (!isEnabled)
            {
                isEnabled = true;
                _follower.pathCreator = _loopPath;
                _follower.pathCreator.bezierPath.SetPoint(0, _loopPath.bezierPath.GetPoint(0));
                _follower.distanceTravelled = 0;
            }
           
        }
    }


}
