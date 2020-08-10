using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleProjectile : MonoBehaviour
{
    public float speed = 10f;
    private float lifetime = 6f;

    // Update is called once per frame

    private void Start()
    {
        SelfDestructionAfterTime(); // don't occupy resource after flying away
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
