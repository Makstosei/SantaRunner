using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DeerStackControllerNew : MonoBehaviour
{
    [SerializeField] private Transform _santaSleigh;
    [SerializeField] private Transform _followObject;
    [SerializeField] private PathCreation.Examples.PathFollower _pathFollower;
    [SerializeField] private List<Transform> _deerList = new List<Transform>();
    [SerializeField] private List<Transform> _movingDeerList = new List<Transform>();

    private void OnEnable()
    {
        EventManager.onCollectNewDear += CollectNewDearEvent;
    }

    private void OnDisable()
    {
        EventManager.onCollectNewDear -= CollectNewDearEvent;

    }

    private void CollectNewDearEvent(Transform transform)
    {
        _deerList.Add(transform);
        transform.parent = _movingDeerList[0].parent;
        UpdateMovingDeerList();
      //EventManager.Instance.onSetCameraPosition(_movingDeerList.Count);
    }

    private void Awake()
    {
        UpdateMovingDeerList();
    }

    void UpdateMovingDeerList()
    {
        _movingDeerList.Clear();
        _movingDeerList.Add(_santaSleigh);
        for (int i = 0; i < _deerList.Count; i++)
        {
            _movingDeerList.Add(_deerList[i]);
        }
        _movingDeerList.Add(_followObject);
    }



    private void Update()
    {
       MoveAll();
    }

    private void AddDeer(Transform deerObject)
    {
        _deerList.Add(deerObject);
    }
    private void RemoveDeer(Transform deerObject)
    {
        _deerList.Remove(deerObject);
    }

    void MoveAll()
    {
        var FakeRotation = _deerList[_deerList.Count - 2].transform.rotation;
        _deerList[_deerList.Count - 1].transform.DORotateQuaternion(FakeRotation, 0.5f);

        for (int i = _movingDeerList.Count - 2; i > -1; i--)
        {
            var currentDeerPosition = _movingDeerList[i].position;
            var previousDeerPosition = _movingDeerList[i + 1].GetChild(2).transform.position;
            var targetPosition = new Vector3(previousDeerPosition.x, previousDeerPosition.y,currentDeerPosition.z);


            if (currentDeerPosition != targetPosition)
            {
                _movingDeerList[i].transform.DOLocalMove(targetPosition, 0.3f);
            }



            if (Vector3.Distance(currentDeerPosition, targetPosition) < 1 || _pathFollower.speed > 0)
            {
                _movingDeerList[i].transform.DOLookAt(targetPosition, 0.7f);
            }
        }

    }
}




