using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private float horizontalInput;
    private bool jumpKeyWasPressed;
    private bool isGround;
    private int superJumps;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Transform groundCheckTransform = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizontalInput * 4, GetComponent<Rigidbody>().velocity.y, 0);


        if (Physics.OverlapSphere(groundCheckTransform.position,0.1f, playerMask).Length == 0)
            return;

       

        //if (!isGround)
        //{
        //    return;
        //}
       

        if (jumpKeyWasPressed)
        {
            float jumpPower = 5;
            if (superJumps>0)
            {
                jumpPower *= 2;
                superJumps--;
            }
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

       
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    isGround = true;
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    isGround = false;
    //}


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer==7)
        {
            Destroy(other.gameObject);
            superJumps++;
        }
    }

}
