using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charcterController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ammo;
    public Text ammoCountText;
    int ammoCount=10;
    int rocketCount = 5;
    public GameObject rocket;
    public GameObject gun;
    public Text healthText;
     int health=100;
    int gunSelect = 1;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public float spreadAngel=5f;
    public int spreadCount=20;
    public float bulletVel = 5f;
    public AudioSource shotGunSound;
    public AudioSource RocketSound;
    public AudioSource LaserSound;
    public LineRenderer line;

    float sec = 0;

    void Start()
    {
       
    }
    private void FixedUpdate()
    {
        if (gunSelect==1)
        {
            ammoCountText.text = "10/" + ammoCount + "";
        }
        else if (gunSelect==3)
        {
            ammoCountText.text = "5/" + rocketCount + "";
        }
        healthText.text = "" + health + "";
    }

    // Update is called once per frame
    void Update()
    {

        if (gunSelect==2)
        {
            Vector3 pos = gun.transform.TransformDirection(gun.transform.position);
            
                    line.SetPosition(0, pos);
                    line.SetPosition(1, pos+gun.transform.forward*20);
              

            
        }


        sec += Time.deltaTime;
        //Mouse1 Click
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (sec>0.25f)
            {
                sec = 0;
                fire();

            }

        }
        //Gun Select
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun1.gameObject.SetActive(true);
            gun2.gameObject.SetActive(false);
            gun3.gameObject.SetActive(false);
            gunSelect = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gun1.gameObject.SetActive(false);
            gun2.gameObject.SetActive(true);
            gun3.gameObject.SetActive(false);
            gunSelect = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gun1.gameObject.SetActive(false);
            gun2.gameObject.SetActive(false);
            gun3.gameObject.SetActive(true);
            gunSelect = 3;
        }

        

    }
    
    void fire()
    {

        if (gunSelect==1)
        {
            if (ammoCount>0)
            {

            
            //ShotGun Fire
            ammoCount--;
            shotGunSound.Play();
            for (int i = 0; i < 20; i++)
            {
                
                GameObject bullet = (GameObject)Instantiate(ammo,gun.transform.position, gun.transform.rotation) as GameObject;
                bullet.transform.rotation = Quaternion.RotateTowards(bullet.transform.rotation, Random.rotation, spreadAngel);
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletVel);
                Destroy(bullet, 5f);
            }

            }
        }

        if (gunSelect == 2)
        {
            //Laser Fire
            
           


        }
        if (gunSelect == 3)
        {
            //Rocket Fire
            if (rocketCount>0)
            {

            
            rocketCount--;
            RocketSound.Play();
            GameObject bullet = (GameObject)Instantiate(rocket, gun.transform.position, gun.transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletVel);
            Destroy(bullet, 5f);

            }

        }




    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("ammoBox"))
        {
            Destroy(other.gameObject);
            ammoCount+=5;
            rocketCount += 2;
            if (rocketCount>5)
            {
                rocketCount = 5;
            }
            if (ammoCount>10)
            {
                ammoCount = 10;
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
