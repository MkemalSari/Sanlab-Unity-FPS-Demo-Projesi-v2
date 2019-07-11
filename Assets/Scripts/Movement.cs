using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Movement
  public void movement(GameObject obje, float rightMax, float leftMax, bool left, bool right,float speed=1)
    {

        if (obje.transform.position.x > rightMax)
        {
            left = true;
            right = false;
        }
        if (obje.transform.position.x < leftMax)
        {
            left = false;
            right = true;
        }

        if (left)
        {
            obje.transform.Translate(new Vector3(-0.1f * speed, 0, 0));
        }
        if (right)
        {
            obje.transform.Translate(new Vector3(0.1f * speed, 0, 0));
        }

    }
}
