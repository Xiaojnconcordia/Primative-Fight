using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 150f;
    

    
    private Transform playerTarget;
    private Rigidbody enemyRb;
    private EnemyAnimation enemyAnim;

    
    public float followRange = 10f;
    public float attackRange = 3f;

    private float defaultAttackTime = 3f;
    public float currentAttackTime;

    

    void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyAnim = GetComponentInChildren<EnemyAnimation>();
        playerTarget = GameObject.FindWithTag("Player").transform;


    }

    // Start is called before the first frame update
    void Start()
    {
        currentAttackTime = defaultAttackTime / 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyMove();
    }


    void EnemyMove()
    {
        if (Vector3.Distance(playerTarget.position, transform.position) > followRange)
        {
            enemyRb.velocity = Vector3.zero;
            enemyAnim.CubeWalk(false);
            enemyAnim.CubeStay();
        }
        
        if (Vector3.Distance(playerTarget.position, transform.position) < followRange
            && Vector3.Distance(playerTarget.position, transform.position) > attackRange)
        {
            transform.LookAt(playerTarget);
            enemyRb.velocity = transform.forward * speed * Time.deltaTime;
            enemyAnim.CubeWalk(true);
        }

        if (Vector3.Distance(playerTarget.position, transform.position) <= attackRange)
        {
            enemyRb.velocity = Vector3.zero;
            enemyAnim.CubeWalk(false);
            EnemyAttack();
        }
    }

    void EnemyAttack()
    {
        currentAttackTime += Time.deltaTime;
        if (currentAttackTime > defaultAttackTime)
        {
            enemyAnim.CubeAttack();
            currentAttackTime = 0;
        }    
    }
}
