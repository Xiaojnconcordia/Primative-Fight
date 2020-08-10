using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator enemyAnim;

    // Start is called before the first frame update
    void Awake()
    {
        enemyAnim = GetComponent<Animator>();
    }

    public void CubeWalk(bool isWalk)
    {
        enemyAnim.SetBool("CubeWalk", isWalk);
    }

    public void CubeStay()
    {
        enemyAnim.SetTrigger("CubeStay");
    }

    public void CubeAttack()
    {
        enemyAnim.SetTrigger("CubeAttack");
    }

    public void PlayCubeDied()
    {
        enemyAnim.Play("CubeDied");
    }

    public void PlayCubeDamaged()
    {
        enemyAnim.Play("CubeDamaged");
    }

    public void PlaySphereDamaged()
    {
        enemyAnim.Play("SphereDamaged");
    }

    public void PlaySphereDied()
    {
        enemyAnim.Play("SphereDied");
    }

    public void PlayCylinderDamaged()
    {
        enemyAnim.Play("CylinderDamaged");
    }

    public void PlayCylinderDied()
    {
        enemyAnim.Play("CylinderDied");
    }

    public void CapsuleExpand(bool shouldExpand)
    {
        enemyAnim.SetBool("ShouldExpand", shouldExpand);
    }

    public void PlayCapsuleFire()
    {
        enemyAnim.Play("CapsuleFire");
    }

    public void TriggerCylinderExpand()
    {        
        enemyAnim.SetTrigger("CylinderExpand");
    }



}
