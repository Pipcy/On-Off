using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photo : MonoBehaviour
{
    public GameObject Trigger;
    public bool PlayerInReach = false;
    public bool On = false;

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
            }
            else if (On == false)
            {
                On = true;
                lampLight.enabled = true;
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
