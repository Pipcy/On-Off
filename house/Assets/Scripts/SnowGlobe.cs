using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnowGlobe : MonoBehaviour
{
    public GameObject Trigger;
    public bool PlayerInReach = false;
    public bool On = false;
    public TextMeshProUGUI txtToDisplay;

    public AudioSource turnOn;
    public AudioSource turnOff;

    private Light lampLight;

    void Start()
    {
        Trigger.SetActive(false);
        lampLight = GetComponent<Light>();
        lampLight.enabled = false;
        txtToDisplay.enabled = false;
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
                turnOn.Pause();
                txtToDisplay.enabled = false;

            }
            else if (On == false)
            {
                On = true;
                lampLight.enabled = true;
                turnOn.Play();
                txtToDisplay.text = "What a beautiful snow globe!";

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
            txtToDisplay.enabled = true;
            txtToDisplay.text = "Turn on snow globe";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //show trigger Image
            PlayerInReach = false;
            Trigger.SetActive(false);
            txtToDisplay.enabled = false;
        }
    }
}
