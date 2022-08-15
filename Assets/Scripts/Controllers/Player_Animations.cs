using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour
{
   
    Animator _anim;


    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void Walk() 
    {
        _anim.SetFloat("Move", 1);
    }

    public void idle()
    {
        _anim.SetFloat("Move", 0);
    }
}
