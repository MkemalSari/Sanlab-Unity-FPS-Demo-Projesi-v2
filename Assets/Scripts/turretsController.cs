using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretsController : Enemies
{
    // Start is called before the first frame update    

    float sec=0;

    // Update is called once per frame
    void Update()
    {

        LookAtTarget();
        sec += Time.deltaTime;
        if (sec > fireRate)
        {
            EnemiesFire();
            sec = 0;
        }

    }


   public void explosion(int dist) {

        health -= (100/dist);

    }
    
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("ammo"))
        {
            Destroy(other.gameObject);
            health -= 20;
            if (health<=0)
            {
                Destroy(gameObject);
            }
        }

        if (other.gameObject.CompareTag("rocket"))
        {

            Destroy(other.gameObject);
            health -= 50;
            
          
        }
    }
}
   

