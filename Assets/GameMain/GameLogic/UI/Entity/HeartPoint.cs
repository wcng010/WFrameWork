using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HeartPoint : MonoBehaviour
{ 
    [SerializeField]private Animator animator;


    public void Disappear()
    {
        animator.enabled = true;
        animator.SetTrigger("Disappear");
    }

    public void Setfalse()
    {
        gameObject.SetActive(false);
    }


}
