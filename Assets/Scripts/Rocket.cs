using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject firework;


    private void OnTriggerEnter(Collider other)
    {
       float distance= Vector3.Distance(transform.position, other.transform.position);
      // Debug.Log(other.gameObject.name+"  "+ distance);

        // other.gameObject.tag == "wall" || other.gameObject.tag == "turret" || other.gameObject.tag == "plane"
        if (!(other.gameObject.CompareTag("ammo")))
        {
           GameObject exlosionEfect= Instantiate(firework, transform.position, Quaternion.identity); //Create Explosion Efect
              Destroy(exlosionEfect, 5f);//Delete Explosion Efect
            Collider[] nearbyobject = Physics.OverlapSphere(transform.position, RocketLauncher.ExplosionArea);//nearby object The area

            foreach (var item in nearbyobject)
            {
                if (item.CompareTag("brick"))
                {
                    item.GetComponent<Rigidbody>().AddExplosionForce(400f, transform.position, 5f); 
                }





                if (item.CompareTag("turret"))
                {
                    
                    var dist = Vector3.Distance(item.transform.position, transform.position);
                    Debug.Log(dist);
                 
                    Enemies enemies = item.GetComponent<Enemies>();
                    if (enemies != null)
                    {
                        enemies.explosion((int)dist); 
                    }
                }
            }
            Destroy(gameObject);
        }


    }
   

}
