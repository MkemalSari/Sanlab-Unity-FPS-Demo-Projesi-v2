using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charcterController : MonoBehaviour
{
    // Start is called before the first frame update

    public int health=100;
    int gunSelect = 1;
    public LineRenderer line;
    public GameObject[] guns;
    float sec = 0;
    public ShotGun shotGun;
    public RocketLauncher rocketLauncher;
    public Laser laser;
    
    void Start()
    {
        shotGun = guns[0].GetComponent<ShotGun>();
        laser= guns[1].GetComponent<Laser>();
        rocketLauncher = guns[2].GetComponent<RocketLauncher>();

    }
    private void FixedUpdate()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (gunSelect==2)
        {
            Vector3 pos = shotGun.burrel.transform.TransformDirection(shotGun.burrel.transform.position);
            
                    line.SetPosition(0, pos);
                    line.SetPosition(1, pos+ shotGun.burrel.transform.forward*20);
                
        }


        sec += Time.deltaTime;
        //Mouse1 Click
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (sec>0.25f)
            {
                if (gunSelect==1)
                {

                    Fire();
                }
                sec = 0;
                Fire();

            }

        }
        //Gun Select
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AllDeactiveGuns();
            guns[0].gameObject.SetActive(true);
            gunSelect = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AllDeactiveGuns();
            guns[1].gameObject.SetActive(true);
            gunSelect = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AllDeactiveGuns();
            guns[2].gameObject.SetActive(true);
            gunSelect = 3;
        }

        

    }
    void AllDeactiveGuns() { //all guns Deactive
        guns[0].gameObject.SetActive(false);
        guns[1].gameObject.SetActive(false);
        guns[2].gameObject.SetActive(false);
    }
    void Fire()
    {      //Guns Fire Control
        if (gunSelect==1) shotGun.Shot(); //Shotgun Fire
        if (gunSelect == 2) { }
        if (gunSelect == 3) rocketLauncher.Shot(); //Rocket Fire
    }


    public int GetGunSelect() { 
        return gunSelect;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Collect AmmoBox
        if (other.gameObject.CompareTag("ammoBox"))
        {
            Destroy(other.gameObject);
            shotGun.ammoCount+=5;
            rocketLauncher.ammoCount += 2;
            if (rocketLauncher.ammoCount > 5)
            {
                rocketLauncher.ammoCount = 5;
            }
            if (shotGun.ammoCount > 10)
            {
                shotGun.ammoCount = 10;
            }
           ;
        }
        
        if (other.gameObject.CompareTag("ammo"))
        {
            Destroy(other.gameObject);
            health -= 10;
            if (health <= 0)
            {
                Debug.Log("Death");
            }


        }
    }
}
