using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagement : MonoBehaviour
{
    public float health = 100f;
    private float projectileDamage = 10f;
    private float kickedBackSphereDamage = 40f;
    public PlayerAnimation playerAnim; // used in AnimationEvent
    private EnemyAnimation enemyAnim;
    private Image healthBar;
    public GameObject gameoverMenu;
    public GameObject completeLevelMenu;

    private bool CharacterDied;
    public bool isPlayer; // check the box in inspector window if this script is attached on player
    public bool isCube;
    public bool isSphere;
    public bool isCylinder;
    private bool playerDead;

    private void Awake()
    {
        if (isPlayer)
        {
            playerAnim = GetComponentInChildren<PlayerAnimation>();
            healthBar = GameObject.FindWithTag("HealthBar").GetComponent<Image>();            
        }
        else
        {
            enemyAnim = GetComponentInChildren<EnemyAnimation>();            
        }

        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerDead)
        //{
        //    //player and enemies should not move or attack after player died
        //    GetComponent<PlayerMovement>().enabled = false;
        //    GetComponent<PlayerAttack>().enabled = false;
        //    GetComponent<CapsuleAttack>().enabled = false;
        //    GetComponent<CylinderAttack>().enabled = false;
        //    GetComponent<SphereAttack>().enabled = false;
        //    GetComponent<EnemyMovement>().enabled = false;
        //    GameObject.FindWithTag("BossPlatform").GetComponent<Animator>().enabled = false;
        //    GameOver();
        //}
    }


    public void TakeDamage(float damage)
    {
        if (CharacterDied)
        {
            return;
        }
        else
        {
            health -= damage;
            //Debug.Log("damage made");

            // play get hurt animation here
            if (isCube)
            {
                enemyAnim.PlayCubeDamaged();
            }

            if (isPlayer)
            {
                playerAnim.PlayPlayerHurt();
            }

            if (isCylinder)
            {
                enemyAnim.PlayCylinderDamaged();
            }
            //sphere's damage and death is dealt within the OnTriggerEnter below in this script

        } // health reduction 

        
        // died
        if (health <= 0f)
        {                      
            if (isCube)
            {   
                // display enemy died animation
                enemyAnim.PlayCubeDied();
                GetComponent<BoxCollider>().enabled = false;
                //enemy should not move or attack after it died or the player character died
                GetComponent<EnemyMovement>().enabled = false;
            }

            if (isCylinder)
            {
                enemyAnim.PlayCylinderDied();
                GetComponent<CapsuleCollider>().enabled = false;
                GetComponent<CylinderAttack>().enabled = false;
            }   

            if (isPlayer)
            {
                PlayerDied();
            }
            return;
        } //died

        if (isPlayer)
        {
            // display healthUI here
            DisplayHealth(health);
        }

    } // take damage

    public void PlayerDied() // used in AnimationEvent
    {
        // display enemy died animation
        playerAnim.PlayPlayerDied();        
        GameOver();
    }


    void PlayerHurtByCylinderKnocking()
    {
        if (isPlayer)
        {
            if (health > 10)
            {
                health -= projectileDamage;
                playerAnim.PlayPlayerHurt();
            }
            else
            {
                PlayerDied();
                
                
                // stop knocking
            }
        }
    }

    void DisplayHealth(float value)
    {
        value = value / 200;
        if (value < 0)
        {
            value = 0;
        }
        healthBar.fillAmount = value;
    }

    void GameOver()
    {        
        gameoverMenu.SetActive(true);
        Invoke("PauseGame", 2.0f);
    }
    void CompleteLevel()
    {
        completeLevelMenu.SetActive(true);
        Invoke("PauseGame", 2.0f);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void OnTriggerEnter(Collider other)
    {


        //sphere enemy can be damaged by kicked back sphere
        if (other.CompareTag("KickedBackSphere"))
        {
            //Debug.Log("collide");

            if (isSphere)
            {
                if (health > 20)
                {
                    Debug.Log("health--");
                    health -= kickedBackSphereDamage;
                    enemyAnim.PlaySphereDamaged();
                }
                else
                {
                    enemyAnim.PlaySphereDied();
                    GameObject.FindWithTag("SphereEnemy").GetComponent<SphereAttack>().enabled = false;
                    GameObject.FindWithTag("BossPlatform").GetComponent<Animator>().enabled = false;
                    Invoke("CompleteLevel", 3.0f);
                }
            }
        }

        // player can be damaged by CapsuleProjectile
        if (other.CompareTag("CapsuleProjectile") || other.CompareTag("SphereProjectile"))
        {
            if (isPlayer)
            {
                
                if (health > 10)
                {
                    health -= projectileDamage;
                    playerAnim.PlayPlayerHurt();
                }
                else
                {
                    PlayerDied();
                    GameObject.FindWithTag("CapsuleEnemy").GetComponent<CapsuleAttack>().enabled = false;
                }
                DisplayHealth(health);
            }
        }
    }


}
