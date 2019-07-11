using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallController : MonoBehaviour
{
    // Start is called before the first frame update
   public bool left;
    public bool right;
    public float rightMax;
    public float leftMax;
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {

        if (transform.position.x>rightMax)
        {
            left = true;
            right = false;
        }
        if (transform.position.x < leftMax)
        {
            left = false;
            right = true;
        }

        if (left)
        {
            transform.Translate(new Vector3(-0.1f, 0, 0));
        }
        if (right)
        {
            transform.Translate(new Vector3(0.1f, 0, 0));
        }

    }
    

    



}
