using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankController : Enemies
{

    public float moveSpeed;
    float sec = 0;
    Vector3 velocity = Vector3.zero;
    NavMeshAgent navMesh;



    void Start()

    {
        navMesh = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        healthText.text = health.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        //  LookAtTarget();
        GoToTarget();
        sec += Time.deltaTime;
        if (sec > fireRate)
        {
            EnemiesFire();
            sec = 0;
        }

    }

    void GoToTarget()
    {
        target = FindObjectOfType<PlayerManager>();
        if (target != null)
        {

            if (navMesh != null)
            {
                navMesh.SetDestination(target.transform.position);
            }

            RaycastHit hit;

            if (Physics.Raycast(burrel.transform.position, burrel.transform.forward, out hit, 100f))
            {

                if (hit.transform.gameObject.CompareTag("Player"))
                {


                }
            }
        }

    }



}
