using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackStage
{
    NONE,
    PUNCH1,
    PUNCH2,
    PUNCH3,
    KICK
}


public class PlayerAttack : MonoBehaviour
{
    private PlayerAnimation animScript;
    private float comboExpireTime = 0.4f;
    private float comboTimeLeft;
    private bool comboActive;
    private AttackStage currentAttack;
    private float attackTimesPerSec = 4f; // can only attack 2 times in a second, otherwise the player is too powerful
    private float nextAttackTime = 0;
    public static bool canMove;


    void Awake()
    {
        animScript = GetComponentInChildren<PlayerAnimation>();
    }

    void Start()
    {
        comboTimeLeft = comboExpireTime;
        currentAttack = AttackStage.NONE;
        canMove = true;
    }



    void Update()
    {
        if (Time.time > nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.U)) // if you press super fast, it will not punch as fast
            {
                AttackCombo();
                nextAttackTime = Time.time + 1 / attackTimesPerSec; // next attack can happen in 0.25(1/4) second 
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                DefenseKick();
                nextAttackTime = Time.time + 1 / attackTimesPerSec;
            }
        }
        ResetCombo();
    }

    private void AttackCombo()
    {

        // kick is the last combo
        if (currentAttack == AttackStage.KICK)
        {
            return;
        }        
        comboActive = true;
        comboTimeLeft = comboExpireTime;
        currentAttack++; //move to next punch
        canMove = false;

        //Animation 
        if (currentAttack == AttackStage.PUNCH1)
        {
            animScript.Punch_1();
        }

        if (currentAttack == AttackStage.PUNCH2)
        {
            animScript.Punch_2();
        }

        if (currentAttack == AttackStage.PUNCH3)
        {
            animScript.Punch_3();
        }

        if (currentAttack == AttackStage.KICK)
        {
            animScript.Kick();
        }
    }

    private void DefenseKick()
    {
        animScript.DefenseKick();
    }

    private void ResetCombo()
    {
        if (comboActive)
        {
            comboTimeLeft -= Time.deltaTime;
            if (comboTimeLeft <= 0)
            {
                comboActive = false;
                currentAttack = AttackStage.NONE;
                comboTimeLeft = comboExpireTime;
            }
        }
    }


}
