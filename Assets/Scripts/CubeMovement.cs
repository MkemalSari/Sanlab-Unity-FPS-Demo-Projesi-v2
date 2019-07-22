using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{

    [Header("[Player Options]")]
    public int playerNumber = 1;
    public float rotateSpeed = 180f;
    public float moveSpeed = 10f;
    private Rigidbody rb_Player;
    private float movementVertical;
    private float movementHorizontal;
    public bool jump = false;
    public float jumpSpeed = 10f;
    public float gravityScale = 1f;
    public bool inGround = true;
    public int jumpingCount = 0;
    public Camera cam;


    private void Awake()
    {
        rb_Player = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
           
            
        }
    
        movementVertical = Input.GetAxis("Vertical");
        movementHorizontal = Input.GetAxis("Horizontal");

        if (!jump)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if ( jumpingCount<2)
                {
                    print("Jump");
                    Jump();
                   
                }
                
            }


        }


    }
    private void FixedUpdate()
    {
        
        Move();
        Turn();
        //Vector3 gravity = -gravityScale * Vector3.up;
        //rb_Player.AddForce(gravity, ForceMode.Acceleration);
    }
    void Jump() {
        rb_Player.AddForce(transform.up * jumpSpeed);
        jumpingCount++;
        

    }
    void Turn()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        print(mousePosition+"Mouse position");

        Vector3 direction = new Vector3(mousePosition.x - transform.position.x,0, mousePosition.z - transform.position.z);
        print(direction+"direction Position");
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

    }
    void Move()
    {
        transform.Translate(movementHorizontal * Vector3.right * moveSpeed);
        transform.Translate(movementVertical * Vector3.forward * moveSpeed);

    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plane"))
        {
            print("inGround");
            inGround = true;
            jumpingCount = 0;

        } 
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Plane"))
        {
            print("offGround");
            inGround = false;
        }
    }
}
