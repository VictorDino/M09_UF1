using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 5f;

    public float gravity = 9.8f;

    public float jumpSpeed = 3.5f;

    public float directionY;

    private bool canDoubleJump = false;

    private bool canTripleJump = false;

    public float jumpMultiply = 0.5f;

    public float secondJumpMultiply = 1f;

    public float rotationSpeed = 10f;

    private Animator animator;

    private Vector3 direction;

    public Camera camera;

    public void jumpOnPlatform()
    {
        directionY -= gravity * Time.deltaTime;
        direction.y = directionY;
        directionY = jumpSpeed * 1.5f;
        animator.SetBool("Jump", true);

    }




    void Start()
    {
        controller = GetComponent<CharacterController>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        var isMoving = horizontalMove + verticalMove != 0;

        Vector3 direction = Quaternion.Euler(0,camera.transform.eulerAngles.y,0) * new Vector3 (horizontalMove,0,verticalMove);
        Vector3 moveDirection = direction.normalized;
        

        if (moveDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(moveDirection,Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation,desiredRotation,rotationSpeed * Time.deltaTime);
        }

        animator.SetFloat("velocity", controller.velocity.magnitude);
        




        if (controller.isGrounded) { animator.SetBool("Jump", false); }

        

        if (controller.isGrounded && Input.GetButtonDown("Jump"))
       {
       
           canDoubleJump = true;
       
           canTripleJump = true;
       
           directionY = jumpSpeed;

            animator.SetBool("Jump", true);
       
       
       }
       else if (Input.GetButtonDown("Jump") && canDoubleJump)
       {
       
       
       
           directionY = jumpSpeed * jumpMultiply;
       
           canDoubleJump = false;
       
       
       
       }
       else if (Input.GetButtonDown("Jump") && canTripleJump)
       {

            

            directionY = jumpSpeed * secondJumpMultiply;
       
           canTripleJump = false;




        }

        if(!controller.isGrounded && controller.collisionFlags == CollisionFlags.Sides)
        {
            if (Input.GetButtonDown("Jump"))
            {
                directionY = jumpSpeed * jumpMultiply;

                animator.SetBool("Jump", true);
                
            }

        }


        

        if (controller.isGrounded && Input.GetKey(KeyCode.LeftShift))
        {
            animator.Play("CrouchedIdle");
        }

        /*if (controller.isGrounded && Input.GetKeyDown(KeyCode.LeftShift) && isMoving)
        {
            animator.Play("crouch");
        }*/
        
        /*if (Input.GetKeyDown(KeyCode.Z))
        {

            


          animator.Play("Backflip");
        }*/


        directionY -= gravity * Time.deltaTime;

        direction.y = directionY;

        controller.Move(direction * speed * Time.deltaTime);





    }

   
}