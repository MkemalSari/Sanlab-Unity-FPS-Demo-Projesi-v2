using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketController : MonoBehaviour
{
    public GameObject firework;
    AudioSource explosion;
    // Start is called before the first frame update
    void Start()
    {
        explosion = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       float distance= Vector3.Distance(transform.position, other.transform.position);
       Debug.Log(other.gameObject.name+"  "+ distance);

        // other.gameObject.tag == "wall" || other.gameObject.tag == "turret" || other.gameObject.tag == "plane"
        if (!(other.gameObject.CompareTag("ammo")))
        {
            Instantiate(firework, transform.position, Quaternion.identity);
            explosion.Play();
        }

        if (distance<=0.5f)
        {
           
        }
        else if( distance > 0.5f&& distance <= 1f)
        {

        }
        else if (distance > 1f && distance <= 2f)
        {

        }


        // Debug.Log("güm");

    }
}
