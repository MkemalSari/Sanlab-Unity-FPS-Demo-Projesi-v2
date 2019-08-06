using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject firework;
    public float fireDamage = 0.1f;
    public float destroyTime = 3f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 500);
        Destroy(gameObject, destroyTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        float distance = Vector3.Distance(transform.position, other.transform.position);
        // Debug.Log(other.gameObject.name+"  "+ distance);


        if (!(other.gameObject.CompareTag("ammo")))
        {
            GameObject exlosionEfect = Instantiate(firework, transform.position, Quaternion.identity); //Create Explosion Efect
            Destroy(exlosionEfect, 1f);//Delete Explosion Efect
            Collider[] nearbyobject = Physics.OverlapSphere(transform.position, 10f);//nearby object The area

            foreach (var item in nearbyobject)
            {
                if (item.CompareTag("brick"))
                {
                    item.GetComponent<Rigidbody>().AddExplosionForce(400f, transform.position, 5f);
                }

                if (item.CompareTag("Player"))
                {

                    var dist = Vector3.Distance(item.transform.position, transform.position);
                    Debug.Log(dist);

                    item.GetComponent<PlayerManager>().TakeDamage(1 / dist);

                    //if (enemies != null)
                    //{
                    //    Debug.Log(1 / dist);
                    //    enemies.TakeDamage(1 / dist);
                    //}
                }
            }
            Destroy(gameObject);
        }


    }


}
