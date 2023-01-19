using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations_sc : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {       
    }

    public void Walking(){
        animator.SetBool("Walking" , true);
    }

    public void Falling(){
        
            animator.SetBool("Falling" , true);
    }
}
