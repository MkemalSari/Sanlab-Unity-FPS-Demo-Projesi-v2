using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Pun.Demo.PunBasics;

public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    public float fireDamage = 0.1f;
    public float destroyTime = 3f;
    Rigidbody rb;
    void Start()
    {
        gameObject.SetActive(true);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 500);
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("wall"))
        //{
        //    Destroy(gameObject);

        //}
        //if (other.gameObject.CompareTag("turret"))
        //{
        //    other.GetComponent<Enemies>().TakeDamage((int)fireDamage);
        //}
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerManager>().TakeDamage(fireDamage);
        }




    }
}
