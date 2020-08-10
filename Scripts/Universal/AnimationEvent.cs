using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public GameObject leftHandAttackPoint, rightHandAttackPoint, leftFootAttackPoint, rightFootAttackPoint, cubeAttackPoint;

    [SerializeField]
    private AudioClip playerAttackSound, PlayerHurtSound, PlayerDiedSound, playerJumpSound,CubeAttackSound, EnemyDamagedSound, EnemyDieSound, 
        cylinderDieSound, capsuleShootSound, sphereExplodeSound, knockGroundSound, platformOpenCloseSound;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private GameObject capSuleProjectile;

    [SerializeField]
    private Transform capsule1, capsule2, capsule3, capsule4;

    private HealthManagement playerHealthScript;
    private PlayerMovement playerMoveScript;    
    private CameraPosition camScript;
    private EnemySpawn enemySpawnScript;
    // Start is called before the first frame update
    void Start()
    {
        playerHealthScript = GameObject.FindWithTag("Player").GetComponent<HealthManagement>();
        playerMoveScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        camScript = GameObject.FindWithTag("MainCamera").GetComponent<CameraPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void LeftHandAttackOn()
    {
        leftHandAttackPoint.SetActive(true);
    }

    void LeftHandAttackOff()
    {
        if (leftHandAttackPoint.activeInHierarchy)
        {
            leftHandAttackPoint.SetActive(false);
        }
    }

    void RightHandAttackOn()
    {
        rightHandAttackPoint.SetActive(true);
    }

    void RightHandAttackOff()
    {
        if (rightHandAttackPoint.activeInHierarchy)
        {
            rightHandAttackPoint.SetActive(false);
        }
    }

    void LeftFootAttackOn()
    {
        leftFootAttackPoint.SetActive(true);
    }

    void LeftFootAttackOff()
    {
        if (leftFootAttackPoint.activeInHierarchy)
        {
            leftFootAttackPoint.SetActive(false);
        }
    }

    void RightFootAttackOn()
    {
        rightFootAttackPoint.SetActive(true);
    }

    void RightFootAttackOff()
    {
        if (rightFootAttackPoint.activeInHierarchy)
        {
            rightFootAttackPoint.SetActive(false);
        }
    }

    void CubeAttackOn()
    {
        cubeAttackPoint.SetActive(true);
    }

    void CubeAttackOff()
    {
        if (cubeAttackPoint.activeInHierarchy)
        {
            cubeAttackPoint.SetActive(false);
        }
    }

    void PlayerAttackSoundFX()
    {
        audioSource.volume = 0.6f;
        audioSource.clip = playerAttackSound;
        audioSource.Play();
    }

    void PlayerHurtSoundFX()
    {
        audioSource.volume = 0.9f;
        audioSource.clip = PlayerHurtSound;
        audioSource.Play();
    }

    void PlayerDiedSoundFX()
    {
        audioSource.volume = 0.4f;
        audioSource.clip = PlayerDiedSound;
        audioSource.Play();
    }

    void PlayerJumpSoundFX()
    {
        audioSource.volume = 0.6f;
        audioSource.clip = playerJumpSound;
        audioSource.Play();
    }

    void CubeAttackSoundFX()
    {
        audioSource.volume = 0.5f;
        audioSource.clip = CubeAttackSound;
        audioSource.Play();
    }

    void EnemyDamagedSoundFX()
    {
        audioSource.volume = 0.6f;
        audioSource.clip = EnemyDamagedSound;
        audioSource.Play();
    }

    void EnemyDeathSoundFX()
    {
        audioSource.volume = 0.5f;
        audioSource.clip = EnemyDieSound;
        audioSource.Play();
    }
    void SphereExplodeSoundFX()
    {
        audioSource.volume = 0.5f;
        audioSource.clip = sphereExplodeSound;
        audioSource.Play();
    }

    void CylinderDieSoundFX()
    {
        audioSource.volume = 0.5f;
        audioSource.clip = cylinderDieSound;
        audioSource.Play();
    }
    void CapsuleShootSoundFX()
    {
        audioSource.volume = 1.0f;
        audioSource.clip = capsuleShootSound;
        audioSource.Play();
    }

    void KnockGroundSoundFX()
    {
        audioSource.volume = 0.7f;
        audioSource.clip = knockGroundSound;
        audioSource.Play();
    }

    void PlatformOpenCloseSoundFX()
    {
        audioSource.volume = 0.4f;
        audioSource.clip = platformOpenCloseSound;
        audioSource.Play();
    }

    void CapsuleFire1()
    {
        Instantiate(capSuleProjectile, capsule1.transform.position, transform.rotation * Quaternion.Euler(-90f, 0, 0f));
    }

    void CapsuleFire2()
    {
        Instantiate(capSuleProjectile, capsule2.transform.position, transform.rotation * Quaternion.Euler(-90f, 0, 0f));
    }

    void CapsuleFire3()
    {
        Instantiate(capSuleProjectile, capsule3.transform.position, transform.rotation * Quaternion.Euler(-90f, 0, 0f));
    }

    void CapsuleFire4()
    {
        Instantiate(capSuleProjectile, capsule4.transform.position, transform.rotation * Quaternion.Euler(-90f, 0, 0f));
    }

    void HurtPlayerWhenKnockingGround()
    {
        if (playerHealthScript.isPlayer)
        {
            if (playerMoveScript.isGrounded)
            {
                if (playerHealthScript.health > 10)
                {
                    playerHealthScript.health -= 10;
                    playerHealthScript.playerAnim.PlayPlayerHurt();
                }
                else
                {
                    playerHealthScript.PlayerDied();
                    GameObject.FindWithTag("CapsuleEnemy").GetComponent<CapsuleAttack>().enabled = false;
                }
            }            
        }        
    }

    void EnableSphereAttack()
    {
        GameObject.FindWithTag("SphereEnemy").GetComponent<SphereAttack>().enabled = true;
    }

    void DisableSphereAttack()
    {
        GameObject.FindWithTag("SphereEnemy").GetComponent<SphereAttack>().enabled = false;
    }


    void ShakeCameraInAnimationEvent()
    {
        camScript.SetShouldShake(true);
    }

    void SummonMinions()
    {
        enemySpawnScript.SpawnMinions();
    }
}
