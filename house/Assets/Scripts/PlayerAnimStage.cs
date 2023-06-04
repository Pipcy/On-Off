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
    public bool sat = false;

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

        bool SofaTrigger = Input.GetKeyDown(KeyCode.E) && sofaInReach;
        anim.SetBool("sitting", SofaTrigger && sat == false);

        if (SofaTrigger)
        {
            if(sat == false)
            {
                SitDown();
            }
            else if(sat == true)
            {
                GetUp();
            }
        }

        void SitDown()
        {
            StartCoroutine(SitOnSofa());
    
            sat = true;
            anim.SetBool("sat", sat);
            
        }

        void GetUp()
        {
            anim.SetBool("sat", false);
            sat = false;
        }

         IEnumerator SitOnSofa()
        {
            if (walking)
                yield break;


            yield return StartCoroutine(WalkToLocation(targetLocation.position));
            yield return StartCoroutine(TurnToRotation(targetRotation));
            
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

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("sofa"))
        {
            sofaInReach = false;
        }
    }

}
