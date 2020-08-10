using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseKickAttackPoint : MonoBehaviour
{
    public LayerMask targetLayer;
    public float radius = 0.2f;
    public float kickbackSpeed = -20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KickBack();
    }

    private void KickBack()
    {

        Collider[] hitTargets = Physics.OverlapSphere(transform.position, radius, targetLayer);
        //Debug.Log("Kick Back!");
        gameObject.SetActive(false); // after on colliction, deactivate attack point so that it will not hit multiple times
        foreach(Collider target in hitTargets)
        {
            target.GetComponent<SphereProjectile>().speed = kickbackSpeed;
            target.tag = "KickedBackSphere";
        }
        

    }
}
