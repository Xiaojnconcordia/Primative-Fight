using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAttack : MonoBehaviour
{
    [SerializeField]
    private Transform followTarget;
    [SerializeField]
    private GameObject sphereProjectile;
    public Vector3 aimOffset;
    private EnemyAnimation enemyAnim;


    public float FireRange = 20f;

    private float defaultAttackTime = 5f;
    public float currentAttackTime;


    void Start()
    {
        currentAttackTime = defaultAttackTime / 2;
    }

    void Awake()
    {
        enemyAnim = GetComponentInChildren<EnemyAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        SphereFire();
    }

    void SphereFire()
    {
        //enemyAnim.CapsuleExpand(true);
        transform.LookAt(followTarget.position + aimOffset);
        currentAttackTime += Time.deltaTime;
        if (currentAttackTime > defaultAttackTime)
        {
            Instantiate(sphereProjectile, transform.position, transform.rotation);//* Quaternion.Euler(-90f, 0, 0f)
            currentAttackTime = 0;
        }
    }
}
