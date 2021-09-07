using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    float throwForce = 200f;

    private bool isMoving = false;
    
    [SerializeField]
    private float flyingSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = false;
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        // if (isMoving)
        // {
        //     transform.Translate(new Vector3(0, -1, 0)  * flyingSpeed * Time.deltaTime);
        // }
    }

    private void FixedUpdate()
    {
        // if (isMoving)
        // {
        //     Vector3 forwardMove = new Vector3(0, -1, 0) * flyingSpeed * Time.fixedDeltaTime;
        //     rb.MovePosition(rb.position + forwardMove);
        // }
    }

    public void Release(){
        //rb.rotation = transform.parent.rotation;
        transform.parent = null;
      
        
        rb.useGravity = true;
        isMoving = true;
        rb.AddForce(new Vector3(0f, 0f, 1f) * throwForce, ForceMode.Impulse);
       
    }
}
