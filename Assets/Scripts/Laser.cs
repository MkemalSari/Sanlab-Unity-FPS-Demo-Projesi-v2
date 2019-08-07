using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Guns 
{
    LineRenderer line;
    public GameObject lineobje;
    public GameObject beam;
    public bool IsFiring;

    IEnumerator Delay() {

        yield return new WaitForSeconds(0.1f);
        //line.positionCount = 0;
        //Destroy(lineobje,0.2f);
        if (ammoCount <= 0)
        {
            IsFiring = false;
        }
        else
        {
            ammoCount--;
        }
        
        

    }
    public void Shot()
    {
        if (ammoCount>=10)
        {
            IsFiring = true;
        }
        
        //StartCoroutine(Delay());

    }
    private void Start()
    {
        IsFiring = false;
    }
    private void Update()
    {
        
        if (this.beam != null && this.IsFiring &&ammoCount>0)
        {
            this.beam.SetActive(true);
            StartCoroutine(Delay());
        }
        if (this.beam != null && !this.IsFiring)
        {
            this.beam.SetActive(false);
        }
    }

    //public void Shot() {

    //   GameObject lines=Instantiate(lineobje, new Vector3(0, 0, 0), new Quaternion(0, 0, 0,0));
    //   line= lines.GetComponent<LineRenderer>();
    //    int x = Screen.width / 2;
    //    int y = Screen.height / 2;
    //    if (ammoCount >= 10)
    //    {
    //        line.positionCount = 2;
    //    line.SetPosition(0, transform.position);
    //    RaycastHit hit;
    //    Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y, 0));



    //        if (Physics.Raycast(ray.origin, ray.direction, out hit, 500f))
    //        {
    //            ammoCount -= 10;
    //            GunShotSound.Play();
    //            if (hit.collider && !hit.collider.CompareTag("ammo"))
    //            {
    //                if (hit.collider.GetComponent<PlayerManager>()) 
    //                {
    //                    hit.collider.GetComponent<PlayerManager>().TakeDamage(damage);
    //                }
    //                line.SetPosition(1, hit.point);
    //            }
    //            else
    //            {
    //                line.positionCount = 0;
    //            }

    //        }
    //        StartCoroutine(Delay());
    //    }

    //}

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        // We own this player: send the others our data
    //        stream.SendNext(this.IsFiring);


    //    }
    //    else
    //    {
    //        // Network player, receive data
    //        //
    //        this.IsFiring = (bool)stream.ReceiveNext();




    //    }
    //}
}
