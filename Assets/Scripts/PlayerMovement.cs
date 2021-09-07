using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] float jumpforce = 400f;
    [SerializeField] private float horizontalMoveMultiplier = 2;
    [SerializeField] float speedIncreasePerPoint = 0.1f;
    
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] Animator _animator;
    [SerializeField] LayerMask groundMask;
    [SerializeField] private AudioSource dieSound;
    [SerializeField] private AudioSource jumpSound;
    bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
       // transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y < -5)
        {
            Die();
        }

      // transform.position = new Vector3(transform.position.x, 1.2f, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (!alive)
        {
            return;
        }


        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + forwardMove);
    }

    public void MoveHorizontal(InputAction.CallbackContext ctx)
    {
        Vector2 input = ctx.ReadValue<Vector2>();

        if (input.y > 0)
        {
            Jump();
        }
        Vector3 horizontalMove = new Vector3(input.x, 0, 0) * horizontalMoveMultiplier;
        if (rigidbody.position.x < -1 )
        {
            horizontalMove.x++;
        }else if ( rigidbody.position.x > 1)
        {
            horizontalMove.x--;
        }
        rigidbody.MovePosition(rigidbody.position + horizontalMove);
    }

    public void Die()
    {
        dieSound.Play();
        alive = false;
        Invoke("Restart", 2);
    }

    void Restart(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

    public void IncreaseSpeed(){
        speed += speedIncreasePerPoint;
    }

    public void Jump() { 
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        if (isGrounded){
            jumpSound.Play();
            _animator.SetTrigger("Jump");
            rigidbody.AddForce(Vector3.up * jumpforce);
        }
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Rock")
        {
            Debug.Log("Hit by a rock");
            GameManager.instance.Lives--;
        }
        
        if (other.transform.tag == "Enemy")
        {
            Debug.Log("Hit enemy");
            
        }
    }
}
