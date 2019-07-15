using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    public int fireDamage = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("turret"))
        {
            other.GetComponent<Enemies>().TakeDamage(fireDamage);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponentInChildren<charcterController>().TakeDamage(fireDamage);
        }

        
   

    }
}
