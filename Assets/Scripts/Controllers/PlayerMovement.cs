using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _swipeSpeed;
    [SerializeField] private float _clampDistance = 3;
    [SerializeField] private bool _cantMove;
    [SerializeField] private bool _isFinishLine;
    private Vector3 _targetPosition;
    private float _xOffset;
    private float _yOffset;
    private float _x;
    private float _y;

    private void Awake()
    {
        _cantMove = true;
    }
    public void StartGame()
    {
        _cantMove = false;
    }

    public void StopMovement()
    {
        _cantMove = true;
    }

    public void FinishLine()
    {
        _cantMove = true;
        _isFinishLine = true;
        DOTween.PauseAll();
        DOTween.KillAll();
        DOTween.ClearCachedTweens();

        _yOffset = 0;
        _xOffset = 0;
        _targetPosition = new Vector3(0, 0, 0);
        transform.DOLocalMove(new Vector3(0, 0, 0), 0.3f);
    }




    void Update()
    {
        gameObject.transform.forward = gameObject.transform.parent.forward;
        if (!_isFinishLine && !_cantMove)
        {
            if (Input.GetMouseButton(0))
            {
                _x = Input.GetAxis("Mouse X");
                _y = Input.GetAxis("Mouse Y");
                _xOffset = Mathf.Clamp(_xOffset + _x * Time.deltaTime * _swipeSpeed, -_clampDistance, _clampDistance);
                _yOffset = Mathf.Clamp(_yOffset + _y * Time.deltaTime * _swipeSpeed, -_clampDistance, _clampDistance);
            }

            if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonDown(0))
            {
                _x = 0;
                _y = 0;
            }

            _targetPosition = new Vector3(_xOffset, _yOffset, 0);
            transform.localPosition = _targetPosition;
        }




    }




}
