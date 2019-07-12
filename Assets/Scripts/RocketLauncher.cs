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
            GunShotSound.Play();
           
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, burrel.transform.position, burrel.transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletVelocity);
                Destroy(bullet, 5f);
           
            
        }


    }
}
