using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Guns
{
    public LineRenderer line;


    IEnumerator Delay() {

        yield return new WaitForSeconds(0.3f);
        line.positionCount = 0;

    }


    public void FireLaser() {

        int x = Screen.width / 2;
        int y = Screen.height / 2;
        if (ammoCount >= 10)
        {
            line.positionCount = 2;
        line.SetPosition(0, transform.position);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y, 0));
        

        
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 500f))
            {
                ammoCount -= 10;
                GunShotSound.Play();
                if (hit.collider && !hit.collider.CompareTag("ammo"))
                {
                    if (hit.collider.GetComponent<Enemies>()) 
                    {
                        hit.collider.GetComponent<Enemies>().TakeDamage(damage);
                    }
                    line.SetPosition(1, hit.point);
                }
                else
                {
                    line.positionCount = 0;
                }

            }
            StartCoroutine(Delay());
        }
       
    }
}
