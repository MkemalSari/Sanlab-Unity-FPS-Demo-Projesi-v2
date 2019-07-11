using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turretsController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
     int health = 100;
    public TextMesh text;
    public GameObject turretFire;
    public GameObject TurrentAmmo;
    float sec = 0;
     public bool toMove;
    public bool left;
    public bool right;
    public float rightMax;
    public float leftMax;
    public float speed = 1f;
    bool isBoom;
    


    void Start()
    {
    }
    private void FixedUpdate()
    {
        text.text = health.ToString();
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
   

    // Update is called once per frame
    void Update()
    {

        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;

        sec += Time.deltaTime;
        if (sec>0.25f)
        {
            GameObject bullet = (GameObject)Instantiate(TurrentAmmo, turretFire.transform.position, turretFire.transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 500);
            Destroy(bullet, 5f);
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
   

