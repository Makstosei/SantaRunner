using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerMovementFree : MonoBehaviour
{
    [SerializeField] private float _swipeSpeed;
    [SerializeField] private float _clampDistance = 3;
    [SerializeField] private float _xOffset;
    [SerializeField] private float _yOffset;
    [SerializeField] private Transform _deerListController;
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _turnSpeed = 10;
    [SerializeField] private GameObject _firstDeer;
    private Vector3 _targetPosition;
    private bool _isFinal;
    private float _x;
    private float _y;
    private bool _cantMove;
    private bool _isGameStarted;

    private int _clampstatus = 0;  // 0 tam , 1 = left, 2 = right

    public Vector3 Point { get; private set; }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void GameStart()
    {
        _isGameStarted = true;
    }

    public void JustStop()
    {
        CantMoveFunc(true);
    }
    public void CantMoveFunc(bool value)
    {
        _cantMove = value;
    }


    void Update()
    {

        if (!_isFinal && !_cantMove)
        {
            if (Input.GetMouseButton(0))
            {
                _x = Input.GetAxis("Mouse X");
                _y = Input.GetAxis("Mouse Y");
                Vector3 rotationy = Vector3.forward * _y + Vector3.right * _x;
                Vector3 rotationx = Vector3.up * _x + Vector3.right * _y;

                var rotationVector = new Vector3(Mathf.Clamp(-_y, -0.8f, 0.8f), Mathf.Clamp(_x, -0.8f, 0.8f), 0);

                if (rotationVector * _turnSpeed * Time.deltaTime !=Vector3.zero)
                {
                    transform.Rotate(rotationVector * _turnSpeed * Time.deltaTime);
                }
            }

            if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonDown(0))
            {
                _x = 0;
                _y = 0;
            }
        }


        gameObject.transform.position += gameObject.transform.forward * _speed * Time.deltaTime;




    }




}
