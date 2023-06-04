using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimStage : MonoBehaviour
{
    //For animation
    Animator anim;

    //walking
    public bool walking;

    //sitting
    public Transform targetLocation;
    public Quaternion targetRotation;
    public bool sitting;

    //Interactive Object In Reach Booleans
    public bool sofaInReach = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //------------ Walking --------------------------------
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != 0 || vertical != 0)
        {
            walking = true;
        }
        else
        {
            walking = false;
        }

        anim.SetBool("walking", walking);

        //------------ Sitting --------------------------------
        if (Input.GetMouseButton(0) && sofaInReach)
        {
            //anim.SetBool("sitting", Input.GetMouseButton(0) && sofaInReach);
            StartCoroutine(SitOnSofa());
        }

        //anim.SetBool("sitting", Input.GetMouseButton(0) && sofaInReach);

         IEnumerator SitOnSofa()
        {
            if (walking)
                yield break;

            walking = true;
            anim.SetBool("walking", true);
            yield return StartCoroutine(WalkToLocation(targetLocation.position));
            yield return StartCoroutine(TurnToRotation(targetRotation));
            walking = false;
            sitting = true;
            anim.SetBool("sitting", true);
            
        }

         IEnumerator WalkToLocation(Vector3 destination)
        {
            while (transform.position != destination)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, 2f * Time.deltaTime);
                yield return null;
            }
        }

         IEnumerator TurnToRotation(Quaternion target)
        {
            while (transform.rotation != target)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target, 180f * Time.deltaTime);
                yield return null;
            }
        }

        //-------------------------------------------------------------------------

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sofa"))
        {
            sofaInReach = true;
        }
        else
        {
            sofaInReach = false;
        }
    }
    
}
