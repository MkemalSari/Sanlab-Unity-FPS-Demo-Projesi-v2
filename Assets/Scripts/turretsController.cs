using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turretsController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
     float health = 100;
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
    Rigidbody rb;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        text.text = health.ToString();


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


        if (toMove)
        {
            if (transform.position.x > rightMax)
            {
                rb.velocity = Vector3.zero;
                left = true;
                right = false;
            }
            if (transform.position.x < leftMax)
            {
                rb.velocity = Vector3.zero;
                left = false;
                right = true;
            }

            if (left)
            {
                rb.AddForce(transform.right * -5f);
                // transform.Translate(new Vector3(-0.1f * speed, 0, 0));

            }
            if (right)
            {
                rb.AddForce(transform.right * 5f);
               // transform.Translate(new Vector3(0.1f * speed, 0, 0));
            }


        }



    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "ammo")
        {
            Destroy(other.gameObject);
            health -= 20;
            if (health<=0)
            {
                Destroy(gameObject);
            }
        }

        if (other.gameObject.tag == "rocket")
        {
            Destroy(other.gameObject);
            health -= 50;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
          
        }
    }
   
}
