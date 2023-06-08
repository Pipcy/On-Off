using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public GameObject Trigger;
    public bool PlayerInReach = false;
    public bool On = false;

    public AudioSource turnOn;
    public AudioSource turnOff;

    private Light lampLight;

    void Start()
    {
        Trigger.SetActive(false);
        lampLight = GetComponent<Light>();
        lampLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerInReach)
        {
            if (On)
            {
                On = false;
                lampLight.enabled = false;
                turnOff.Play();
            }
            else if (On == false)
            {
                On = true;
                lampLight.enabled = true;
                turnOn.Play();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //show trigger Image
            PlayerInReach = true;
            Trigger.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //show trigger Image
            PlayerInReach = false;
            Trigger.SetActive(false);
        }
    }
}
