using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankController : Enemies
{
   
    public float moveSpeed;
    float sec = 0;
    Vector3 velocity = Vector3.zero;
    public NavMeshAgent navMesh;
    void Start()
       
    {
       // navMesh.GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        healthText.text = health.ToString();
    }
    // Update is called once per frame
    void Update()
    {
       LookAtTarget();
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

          RaycastHit hit;

           if (Physics.Raycast(burrel.transform.position, burrel.transform.forward, out hit,100f))
           {
                
                if (hit.transform.gameObject.CompareTag("Player"))
                {
                    if (navMesh!=null)
                    {
                        navMesh.SetDestination(target.transform.position);
                    }
               


                          //      float distance = Vector3.Distance(target.transform.position, transform.position);
                          //if (distance > 10f)
                          //       {// look Smooting Movement;
                          //          transform.position = new Vector3(transform.position.x, 3.34f, transform.position.z);
                          //transform.position = Vector3.SmoothDamp(transform.position, target.transform.position,ref velocity,3f,moveSpeed);
                          //          //transform.Translate(Vector3.forward * moveSpeed);
                }
           }
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("ammo"))
        {
            Destroy(other.gameObject);
            health -= 20;
            Die();
        }

        if (other.gameObject.CompareTag("rocket"))
        {

            Destroy(other.gameObject);
            health -= 50;


        }
    }



}
