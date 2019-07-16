using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretsController : Enemies
{
    // Start is called before the first frame update    

    float sec=0;

    // Update is called once per frame
    void Update()
    {

        LookAtTarget();
        sec += Time.deltaTime;
        if (sec > fireRate)
        {
            EnemiesFire();
            sec = 0;
        }

    }
    private void FixedUpdate()
    {
        healthText.text = health.ToString();
    }

  
}
   

