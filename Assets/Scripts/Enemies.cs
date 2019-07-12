using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : MonoBehaviour
{
    public int health;
    public float fireRate;
    public TextMesh healthText;
    public GameObject target;
    public GameObject enemiesBullet;
    public GameObject burrel;
    public float fireSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    public void LookAtTarget()
    {

        Vector3 relativePos = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;

    }
    public void EnemiesFire()
    {
        GameObject bullet = (GameObject)Instantiate(enemiesBullet, burrel.transform.position, burrel.transform.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * fireSpeed);
        Destroy(bullet, 5f);

    }
    void Update()
    {

    }

    public void explosion(int dist)
    {

        health -= (100 / dist);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
