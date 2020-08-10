using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereProjectile : MonoBehaviour
{
    public float speed = 1f;
    private float lifetime = 4f;
    //[SerializeField]
    //Transform target;
    //Vector3 direction;
    // Update is called once per frame

    private void Start()
    {
        SelfDestructionAfterTime(); // don't occupy resource after flying away
        //direction = (target.localPosition - transform.localPosition).normalized;
        //transform.rotation = transform.rotation * Quaternion.Euler(0, -90, 0);
    }
    void Update()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void SelfDestructionAfterTime()
    {
        StartCoroutine(DestroyPrefab()); //利用下面那个方法，让enemy在standUpTimer秒之后站起来
    }

    IEnumerator DestroyPrefab()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
