﻿using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : MonoBehaviour
{
    public int scoreValue = 10;
    public int health;
    public float fireRate;
    public Text healthText;
    public PlayerManager target;
    public GameObject enemiesBullet;
    public GameObject burrel;
    public float fireSpeed;
    bool death = false;



    void Start()
    {

    }

    // Update is called once per frame
    public void LookAtTarget()
    {
        target = FindObjectOfType<PlayerManager>();
        if (target != null)
        {
            Vector3 relativePos = target.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;
        }



    }
    public void EnemiesFire()
    {
        RaycastHit hit;

        if (Physics.Raycast(burrel.transform.position, burrel.transform.forward, out hit, 100f))
        {
           Debug.DrawRay(burrel.transform.position, burrel.transform.forward* 100f);
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                GameObject bullet = (GameObject)Instantiate(enemiesBullet, burrel.transform.position, burrel.transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * fireSpeed);
                Destroy(bullet, 5f);
            }
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Die();

    }
    public void explosion(int dist)
    {

        health -= (100 / dist);
        Die();
    }
    public void Die()
    {

        if (health <= 0 && !death)
        {
            death = true;


            Destroy(gameObject);
            charcterController.score += 10;
            // death = false;

            //charcterController c = new charcterController();
            //if (c!=null)
            //{
            //    c.score += 10;
            //}

        }
    }
    private void FixedUpdate()
    {

    }
}
