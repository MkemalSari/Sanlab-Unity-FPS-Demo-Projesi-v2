using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Guns
{
    // Start is called before the first frame update
    public static float ExplosionArea=10f;

   

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shot()
    {

        if (ammoCount > 0)
        {
            ammoCount--;
          
                GameObject bullet =PhotonNetwork.Instantiate("RoketV1", burrel.transform.position, burrel.transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(burrel.transform.forward * bulletVelocity);
          
           // Destroy(bullet, 5f);
           
            
        }


    }
}
