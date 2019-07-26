using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun :Guns
{
    // Start is called before the first frame update
    public float spreadAngle;
    public float spreadCount=20;

    //IEnumerator wait()
    //{


    //    yield return new WaitForSeconds(fireRate);
    //    canFire = true;

    //}
    void Start()
    {
      //  StartCoroutine("wait");
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
            for (int i = 0; i < spreadCount; i++)
            {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, burrel.transform.position, burrel.transform.rotation) as GameObject;
            bullet.transform.rotation = Quaternion.RotateTowards(bullet.transform.rotation, Random.rotation, spreadAngle);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletVelocity);
            Destroy(bullet, 5f);
            }
        }


    }

}
