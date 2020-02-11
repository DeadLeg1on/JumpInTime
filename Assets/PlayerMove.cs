using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float minSpeed = 1f,
          maxSpeed = 10f,
          speedUp = 0.1f,
          speed = 600f;

      Rigidbody rb;

      public GameObject MainCamera; 
      public GameObject player; 

      public bool grounded = true;
      bool _gameover = false;
      public bool moveForward = false;

      public float sensitivityHor = 1.0f;

      private float _rotationX = 0;
      

    public void Start()
    {
      rb = GetComponent<Rigidbody>();   

      Rigidbody body = GetComponent<Rigidbody>();
      if (body != null)
      body.freezeRotation = true;
    }

    void Update()
    {

      transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0); //

        if (Input.GetKey(KeyCode.W) & _gameover == false)
        {
            moveForward = true;
            if (grounded == true)
            {
                rb.AddForce(MainCamera.transform.forward * speed * Time.deltaTime);
               
            }
            else
            {
                rb.AddForce(0f, 0f, 0f);
            }
        }
        else
        {
            moveForward = false;
        }
        if (Input.GetKey(KeyCode.Space) & _gameover == false ) 
        {
            rb.AddForce(0f, 50f, 0f);
            //grounded = false;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(0f, -50f, 0f);
        }
    }
    private void OnCollisionEnter(Collision other) 
      {
            if (other.gameObject.tag == "Block")
            {
                  grounded = true; 
            }
            if (other.gameObject.tag == "Jumper")
            {
                rb.AddForce(0f, 1000f, 0f);
            }
           
      }
    private void OnTriggerEnter(Collider other) 
    {
        
    }

    /*void Move()
	{
      
        if (velocity < maxSpeed)
		{
            velocity += speedUp;
		}
            
	}*/
}
