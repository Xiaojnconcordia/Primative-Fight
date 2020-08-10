using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool isWalk)
    {
        anim.SetBool("Walk", isWalk);
    }

    public void Punch_1()
    {
        anim.SetTrigger("Punch1");
    }

    public void Punch_2()
    {
        anim.SetTrigger("Punch2");
    }

    public void Punch_3()
    {
        anim.SetTrigger("Punch3");
    }

    public void Kick()
    {
        anim.SetTrigger("Kick");
    }

    public void Jump()
    {
        anim.SetTrigger("Jump");
    }

    public void DefenseKick()
    {
        anim.SetTrigger("DefenseKick");
    }

    public void ResumeMove()
    {
        PlayerAttack.canMove = true;
    }

    public void PlayPlayerHurt()
    {
        anim.Play("GetHurt");
    }

    public void PlayPlayerDied()
    {
        anim.Play("Died");
    }
}
