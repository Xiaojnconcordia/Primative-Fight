using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    GameObject cubeEnemy, cylinderEnemy;
    Vector3 cube1SpawnOffset = new Vector3(6f, -3f, -3f);
    //Vector3 cube2SpawnOffset = new Vector3(6f,-3f,-14f);
    Vector3 cylinderSpawnOffset = new Vector3 (6f,-2f,-8.5f);
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMinions()
    {
        Instantiate(cubeEnemy, transform.position + cube1SpawnOffset, transform.rotation);
        //Instantiate(cubeEnemy, transform.position + cube2SpawnOffset, transform.rotation);
        Instantiate(cylinderEnemy, transform.position + cylinderSpawnOffset, transform.rotation * Quaternion.Euler(0, 90, 0));
    }
}
