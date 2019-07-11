using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Guns : MonoBehaviour
{

    public float fireRate; //bullet velocity of  weapon
    public int damage; //bullet damage of weapon
    public GameObject bulletPrefab;//need bullet model
    public int ammoCapacity; //have ammo capacity
    public int ammoCount;
    public bool canFire=true; //
    public AudioSource GunShotSound; //
    public float bulletVelocity;
    public GameObject burrel;

   
    // Start is called before the first frame update
    void Start()
    {
       
        
    }
   
   


    // Update is called once per frame
    void Update()
    {
        
    }
}
