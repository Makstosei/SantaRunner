using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace PathCreation.Examples
{
    public class PathFollower : MonoBehaviour
    {
        public FloatingJoystick floatingJoystick;
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5, swipeSpeed = 20, turnspeed = 3, doMoveSpeed;
        public float distanceTravelled, travelledCopy;
        public float xOffset;
        public float yOffset;
        float _look;
        [SerializeField] float clampDistance = 3;
        int clampstatus = 0; // 0 tam , 1 = left, 2 = right
        bool isGameStart, isFinal;
        bool cantMove;
        float oldSpeed;
        // Move 
        // [SerializeField] float _speed;
        float _firstPressPos;
        float _secondPressPos;
        float _currentSwipe;
        private float x;
        private float y;
        bool transformfixed;
        [SerializeField] Vector3 target;


        public void CantMoveFunc(bool value)
        {
            cantMove = value;
        }

        public void FinishLineSpeedUp()
        {
            speed = 30;
        }


        public void GameStart()
        {
            isGameStart = true;
            speed = oldSpeed;
        }
        public void FinalStatus()
        {
            isFinal = true;
        }

        public void JustStop()
        {
            speed = 0;
            CantMoveFunc(true);
        }


   

        void Start()
        {
            oldSpeed = speed;
            speed = 0;
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        IEnumerator waitforFix()
        {
            yield return new WaitForSecondsRealtime(1f);
            transformfixed = false;
            isGameStart = true;
        }


     



        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

       

    }

}