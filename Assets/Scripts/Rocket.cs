using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject firework;
  //  AudioSource explosion;

    // Start is called before the first frame update
    //RocketLauncher rocketLauncher;
    void Start()
    {
       // rocketLauncher = GetComponent<RocketLauncher>();
      //  explosion = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       float distance= Vector3.Distance(transform.position, other.transform.position);
      // Debug.Log(other.gameObject.name+"  "+ distance);

        // other.gameObject.tag == "wall" || other.gameObject.tag == "turret" || other.gameObject.tag == "plane"
        if (!(other.gameObject.CompareTag("ammo")))
        {
            Instantiate(firework, transform.position, Quaternion.identity);
          //  explosion.Play(); //Explosion effect Play
          //  Destroy(explosion, 5f);//Delete Explosion sound
            Collider[] nearbyobject = Physics.OverlapSphere(transform.position, RocketLauncher.ExplosionArea);

            foreach (var item in nearbyobject)
            {
                if (item.CompareTag("brick"))
                {

                    item.GetComponent<Rigidbody>().AddExplosionForce(300f, transform.position, 5f);
                }





                if (item.CompareTag("turret"))
                {
                    
                    var dist = Vector3.Distance(item.transform.position, transform.position);
                    Debug.Log(dist);
                 
                    TurretsController tCt = item.GetComponent<TurretsController>();
                    TankController tankC = item.GetComponent<TankController>();
                    if (tCt != null)
                    {
                        tCt.explosion((int)dist); 
                    }
                    if (tankC != null)
                    {
                        tankC.explosion((int)dist);
                    }

                }
            }
            Destroy(gameObject);
        }


    }
   

}
