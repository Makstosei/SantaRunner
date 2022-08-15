using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BoolSO", menuName = "ScriptableObjects/Variables/BoolSO")]

public class BoolSO : ScriptableObject
{
    [SerializeField]
    private bool value,initialValue;

    public bool Value { get => value; }


    public void ChangeValue(bool changeby)
    {
        value = changeby;
    }


    public void ResetValue()
    {
        value = initialValue;
    }

    public void SetInitialValue(bool value)
    {
        initialValue = value;
    }
}
