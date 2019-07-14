using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charcterController : MonoBehaviour
{
    // Start is called before the first frame update

    public int health=100;
    public int gunSelect = 1;
    public LineRenderer line;
    public GameObject[] guns;
    float sec = 0;
    public ShotGun shotGun;
    public RocketLauncher rocketLauncher;
    public Laser laser;
    public Text ammoCountText;
    public Text healthText;
    public RectTransform healthBar;
    public AudioClip[] hurtsSounds;
    AudioSource audioSource;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        shotGun = guns[0].GetComponent<ShotGun>();
        laser= guns[1].GetComponent<Laser>();
        rocketLauncher = guns[2].GetComponent<RocketLauncher>();
        

    }
    private void FixedUpdate()
    {
       
        if (gunSelect == 1)
        {
            ammoCountText.text = "10/" + shotGun.ammoCount + "";
        }
        else if (gunSelect == 3)
        {
            ammoCountText.text = "5/" + rocketLauncher.ammoCount + "";
        }
        healthText.text = "" + health + "";
    }

    // Update is called once per frame
    void Update()
    {

      


        sec += Time.deltaTime;
        //Mouse1 Click
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (sec>0.25f)
            {
                Fire();
                sec = 0;

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
        if (gunSelect == 2) { laser.FireLaser(); }
        if (gunSelect == 3) rocketLauncher.Shot(); //Rocket Fire
    }


    void HealthBarSetup()
    {
        float minHealth = -(healthBar.rect.width-20);//HealthBar distance;
        healthBar.position += healthBar.right * minHealth/10; //every time you receive damage change position healtbar
        healthBar.GetComponent<Image>().color = Color.Lerp(healthBar.GetComponent<Image>().color, Color.red,0.2f);// every time you receive damage change HealtBar Color
    }

    public void HurtsSoundRandom() { //Select Random Hurts Sounds
       audioSource.clip= hurtsSounds[Random.Range(0, hurtsSounds.Length)];

    }

    private void OnTriggerEnter(Collider other)
    {
        //Collect AmmoBox
        if (other.gameObject.CompareTag("ammoBox"))
        {
            other.gameObject.GetComponent<AudioSource>().Play();
            other.gameObject.transform.position = new Vector3(1000, 1000, 1000);
            Destroy(other.gameObject,2f);
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
            HurtsSoundRandom();
            audioSource.Play();
            Destroy(other.gameObject);
            health -= 10;
            HealthBarSetup();
            if (health <= 0)
            {
                Debug.Log("Death");
            }


        }
    }
}
