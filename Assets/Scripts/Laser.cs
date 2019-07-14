using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer line;
    public Camera cameraFoward;
    public int laserDamage=20;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 center = new Vector3(Screen.height / 2, Screen.width / 2);


       

     //   Debug.DrawRay(transform.position, ray.direction * 1000, new Color(1f, 0.922f, 0.016f, 1f));

    }
    IEnumerator Delay() {

        yield return new WaitForSeconds(0.2f);
        line.positionCount = 0;

    }

    public void FireLaser() {

        
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        line.positionCount = 2;
        line.SetPosition(0, transform.position);
        RaycastHit hit;
        Ray ray = cameraFoward.ScreenPointToRay(new Vector3(x, y, 0));
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 500f))
        {
            if (hit.collider && !hit.collider.CompareTag("ammo"))
            {
                if (hit.collider.GetComponent<Enemies>()) 
                {
                    hit.collider.GetComponent<Enemies>().TakeDamage(laserDamage);
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
