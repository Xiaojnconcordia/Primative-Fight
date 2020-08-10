using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    public LayerMask targetLayer;
    public float radius = 0.2f;
    public float damage = 10;

    public bool isPlayer, isEnemy;
    


    void Start()
    {        
        
    }
    void Update()
    {
        HitOnTarget();
    }

    private void HitOnTarget()
    {
        Collider[] hitTargets = Physics.OverlapSphere(transform.position, radius, targetLayer);
        gameObject.SetActive(false); // after on colliction, deactivate attack point so that it will not hit multiple times
        foreach(Collider target in hitTargets)
        {
            target.GetComponentInParent<HealthManagement>().TakeDamage(damage);
        }
        
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(transform.position, radius);
    //}
}
