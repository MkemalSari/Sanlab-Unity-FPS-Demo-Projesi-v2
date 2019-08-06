using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class charcterController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    //
   
    public static int score=0;
    public int health=100;
    public int gunSelect = 1;
    public GameObject[] guns;
    public float sec = 0;
    public ShotGun shotGun;
    public RocketLauncher rocketLauncher;
    public Laser laser;
    public static GameObject LocalPlayerInstance;
    public RectTransform healthBar;
    public AudioClip[] hurtsSounds;
    AudioSource audioSource;
    public Transform spawnPoint;

    private void Awake()
    {
        if (photonView.IsMine)
        {
            LocalPlayerInstance = gameObject;
        }
    }

    void Start()
    {
       
        audioSource = GetComponent<AudioSource>();
        shotGun = guns[0].GetComponent<ShotGun>();
        laser= guns[1].GetComponent<Laser>();
        rocketLauncher = guns[2].GetComponent<RocketLauncher>();
        StartCoroutine(RechargeLaser());


    }
    private void FixedUpdate()
    {

        if (photonView.IsMine)
        {
           
       
        if (gunSelect == 1)
        {
            //GunsImageDeactive();
            //shotGun.gunsImage.SetActive(true);
           
           // ammoCountText.text = shotGun.ammoCapacity+"/" + shotGun.ammoCount + "";
        }
        else if (gunSelect == 3)
        {
            //GunsImageDeactive();
            //rocketLauncher.gunsImage.SetActive(true);
          
           // ammoCountText.text = rocketLauncher.ammoCapacity+"/" + rocketLauncher.ammoCount + "";
        }
        else if (gunSelect == 2)
        {
            //GunsImageDeactive();
           // laser.gunsImage.SetActive(true);
           
           // ammoCountText.text = laser.ammoCapacity+"/" + laser.ammoCount + "";
        }
      //  healthText.text = "" + health + "";
      //  scoreText.text = ""+score + "";
    }

    }



    //public void GunsImageDeactive() {

    //    shotGun.gunsImage.SetActive(false);
    //    laser.gunsImage.SetActive(false);
    //    rocketLauncher.gunsImage.SetActive(false);

    //}

    // Update is called once per frame
    void Update()
    {

        if (photonView.IsMine)
        {


            sec += Time.deltaTime;
            //Mouse1 Click
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Fire();


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

            if (Input.GetKeyDown(KeyCode.R))
            {
                score = 0;
                SelectScane("SanLabFps");
            }

        }
        void AllDeactiveGuns()
        { //all guns Deactive
            guns[0].gameObject.SetActive(false);
            guns[1].gameObject.SetActive(false);
            guns[2].gameObject.SetActive(false);
        }
        void Fire()
        {      //Guns Fire Control
            if (gunSelect == 1)
            {
                if (sec > shotGun.fireRate)
                {
                    shotGun.Shot(); //Shotgun Fire
                    sec = 0;

                }
            }

            if (gunSelect == 2)
            {
                if (sec > laser.fireRate)
                {
                    laser.FireLaser(); //laseer Fire
                    sec = 0;

                }

            }
            if (gunSelect == 3)
            {
                if (sec > rocketLauncher.fireRate)
                {
                    rocketLauncher.Shot(); //Rocket Fire
                    sec = 0;

                }

            }
        }
    }

    void HealthBarDecrease()
    {
        float minHealth = -(healthBar.rect.width-20);//HealthBar distance;
        healthBar.position += healthBar.right * minHealth/9; //every time you receive damage change position healtbar
        healthBar.GetComponent<Image>().color = Color.Lerp(healthBar.GetComponent<Image>().color, Color.red,0.2f);// every time you receive damage change HealtBar Color
    }
    void HealthBarIncrease()
    {
        float minHealth = -(healthBar.rect.width - 20);//HealthBar distance;
        healthBar.position -= healthBar.right * minHealth / 9; //every time you receive damage change position healtbar
        healthBar.GetComponent<Image>().color = Color.Lerp(healthBar.GetComponent<Image>().color, Color.green, 0.2f);// every time you receive medkit change HealtBar Color
    }

    public void HurtsSoundRandomPlay() { //Select Random Hurts Sounds
       audioSource.clip= hurtsSounds[Random.Range(0, hurtsSounds.Length)];
        audioSource.Play();
    }


    public void TakeDamage(int damage) { //Charcter each take damage
        health -= damage;
        HealthBarDecrease();//Update Health Bar each take damage
        HurtsSoundRandomPlay();// each take damage to hurts Sound play
        Die();

    }

    public void Die()
    {
        if (health<=0)
        {
            Debug.Log("Death");

          //  endGamePanel.SetActive(true);
            Time.timeScale = 0;
            
            //Setup End Game Scene
        }

    }
    public void SelectScane(string sceneName)
    {

        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        Time.timeScale = 1;

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
        //Setup HealhtBox
        if (other.gameObject.CompareTag("healthBox"))
        {
            other.gameObject.transform.position = new Vector3(1000, 1000, 1000);
            Destroy(other.gameObject,2f);
            health += 10;
            HealthBarIncrease();
            if (health >= 100)
            {
                health = 100;
            }


        }

        if (other.gameObject.CompareTag("water"))
        {
        other.gameObject.GetComponent<AudioSource>().Play();
         //  gameObject.GetComponentInParent<Transform>().position=new Vector3( spawnPoint.position.x,spawnPoint.position.y,spawnPoint.position.z);
        TakeDamage(20);
       
        }

        if (other.gameObject.CompareTag("finish"))
        {
            //Setup Finish Scane
            SelectScane("SanLabFps");
        }
    }

    IEnumerator Second() {

        yield return new WaitForSeconds(1f);

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("water"))
        {
            other.gameObject.GetComponent<AudioSource>().Stop();
           
          //  TakeDamage(10);

        }
    }


    IEnumerator RechargeLaser()
    {

        yield return new WaitForSeconds(0.5f);

        if (laser.ammoCount < laser.ammoCapacity)
        {
            laser.ammoCount++;
        }
        StartCoroutine(RechargeLaser());


    }

 
}
