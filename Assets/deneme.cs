using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    // Start is called before the first frame update
    public LineRenderer line;
    public Camera cameraFoward;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 center = new Vector3(Screen.height / 2, Screen.width / 2);
       

        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Vector3 point = cameraFoward.WorldToScreenPoint(new Vector3(x, y));
        Vector3 point2 = cameraFoward.ScreenToWorldPoint(new Vector3(x, y));


        Ray ray = cameraFoward.ScreenPointToRay(new Vector3(x, y,0));

        Debug.DrawRay(transform.position, ray.direction * 1000, new Color(1f, 0.922f, 0.016f, 1f));
        

        line.SetPosition(0, transform.position);
        line.SetPosition(1, ray.direction * 1000);

    }




    
}
