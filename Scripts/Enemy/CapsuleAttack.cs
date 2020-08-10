using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleAttack : MonoBehaviour
{
    
    private Transform playerTarget;
    public Vector3 aimOffset;
    private EnemyAnimation enemyAnim;

    
    public float FireRange = 10f;

    private float defaultAttackTime = 5f;
    public float currentAttackTime;


    void Start()
    {
        currentAttackTime = defaultAttackTime / 2;
    }

    void Awake()
    {
        enemyAnim = GetComponentInChildren<EnemyAnimation>();
        playerTarget = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CapsuleFire();
    }

    void CapsuleFire()
    {
        if (Vector3.Distance(playerTarget.position, transform.position) > FireRange)
        {            
            enemyAnim.CapsuleExpand(false);            
        }

        else
        {
            enemyAnim.CapsuleExpand(true);
            transform.LookAt(playerTarget.position + aimOffset);            
            currentAttackTime += Time.deltaTime;
            if (currentAttackTime > defaultAttackTime)
            {
                enemyAnim.PlayCapsuleFire();
                currentAttackTime = 0;
            }
        }
    }
}
