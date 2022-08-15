using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DeerStackController : MonoBehaviour
{
    [SerializeField] public Transform _santaSleigh;
    [SerializeField] private Transform _firstDeer;
    [SerializeField] private Transform _secondDeer;
    [SerializeField] private Transform _thirdDeer;
    [SerializeField] private Transform _followObject;
    [SerializeField] private PathCreation.Examples.PathFollower _pathFollower;
    [SerializeField] private List<Transform> _deerList = new List<Transform>();
    [SerializeField] private List<Transform> _movingDeerList = new List<Transform>();
    private float _swipeSpeed = 3;

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
        EventManager.Instance.onSetCameraPosition(_movingDeerList.Count);
    }

    private void Awake()
    {
        _deerList.Add(_firstDeer);
        _deerList.Add(_secondDeer);
        _deerList.Add(_thirdDeer);
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
        for (int i = _movingDeerList.Count - 2; i > -1; i--)
        {
            var previousDeerPosition = _movingDeerList[i + 1].transform.position;
            var currentDeerPosition = _movingDeerList[i].transform.position;

            var xoffset = Mathf.Lerp(_movingDeerList[i].position.x, previousDeerPosition.x, _swipeSpeed * Time.deltaTime);
            var yoffset = Mathf.Lerp(_movingDeerList[i].position.y, previousDeerPosition.y, _swipeSpeed * Time.deltaTime);
            var zoffset = Mathf.Lerp(_movingDeerList[i].position.z, previousDeerPosition.z - 2, 10 * Time.deltaTime);
            _movingDeerList[i].transform.position = new Vector3(xoffset, yoffset, zoffset);
            _movingDeerList[i].transform.forward = _movingDeerList[i + 1].transform.forward;
            _movingDeerList[i].transform.LookAt(previousDeerPosition);
        }

    }



    public void FinishLineSpeedChange()
    {
        _swipeSpeed = 5;
    }
}
