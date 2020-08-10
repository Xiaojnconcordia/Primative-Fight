using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderAttack : MonoBehaviour
{    
    Transform target;
    private EnemyAnimation enemyAnim;
    public float attackRange = 10f;
    private float knockRate = 6f;
    private float knockStartTime = 3f;

    // Start is called before the first frame update
    void Awake()
    {
        enemyAnim = GetComponentInChildren<EnemyAnimation>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        KnockGroundAttack();
    }

    private void KnockGroundAttack()
    {
        if (Vector3.Distance(target.position, transform.position) < attackRange)
        {
            enemyAnim.TriggerCylinderExpand();
        }        
    }


}
