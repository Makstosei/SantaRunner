using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildAnimationStartRandomizer : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private GameObject _sleigh;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _sleigh = FindObjectOfType<DeerStackController>()._santaSleigh.gameObject;
    }

    void Start()
    {
        _animator.Play("Wave", -1, Random.Range(0.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(_sleigh.transform);
    }
}
