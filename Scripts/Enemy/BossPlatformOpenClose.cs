﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlatformOpenClose : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Open");
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }


}
