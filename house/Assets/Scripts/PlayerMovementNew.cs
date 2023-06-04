using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNew : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;

    public Transform cam;

    //for smooth turning
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    //For animation
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
      

        if (direction.magnitude >= 0.1f)
        {
            //allow player to face the way they are moving
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            /* "+ cam.eulerAngles.y" add rotation of camera on y axies 
            allow player to point and travel the way the camera is looking */

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMovementNew : MonoBehaviour
//{
//    public CharacterController controller;
//    public float speed = 6f;
//    public float jumpHeight = 3f; // The height the player jumps

//    public Transform cam;

//    //public bool jumping = false;
//    //public bool walking = false;

//    //for jump
//    private bool grounded;
//    public Animator anim;

//    //for smooth turning
//    public float turnSmoothTime = 0.1f;
//    float turnSmoothVelocity;

//    // Vertical velocity for jumping
//    float verticalVelocity;

//    void start()
//    {
//        //anim = GetComponent<Animator>();
//    }

//    void Update()
//    {
//        float horizontal = Input.GetAxisRaw("Horizontal");
//        float vertical = Input.GetAxisRaw("Vertical");
//        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

//        //anim.SetBool("walking", horizontal != 0);

//        if (controller.isGrounded)
//        {
//            // Jump when the Jump button (e.g., Space) is pressed
//            if (Input.GetButtonDown("Jump"))
//            {
//                verticalVelocity = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics.gravity.y));
//                //jumping = true;
//            }
//        }

//        // Apply gravity to the vertical velocity
//        verticalVelocity += Physics.gravity.y * Time.deltaTime;

//        Vector3 moveDir = Vector3.zero;
//        if (direction.magnitude >= 0.1f)
//        {
//            // Allow player to face the way they are moving
//            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

//            /* "+ cam.eulerAngles.y" add rotation of camera on y axis 
//               allow player to point and travel the way the camera is looking */

//            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
//            transform.rotation = Quaternion.Euler(0f, angle, 0f);

//            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
//        }

//        // Apply vertical velocity
//        moveDir.y = verticalVelocity;

//        // Apply movement and gravity
//        controller.Move(moveDir.normalized * speed * Time.deltaTime);
//    }
//}
