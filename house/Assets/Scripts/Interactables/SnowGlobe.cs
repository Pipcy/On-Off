using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnowGlobe : MonoBehaviour
{
    public GameObject Trigger;
    //public MeshRenderer GlobeMesh;
    public bool PlayerInReach = false;
    public bool On = false;
    public bool turnedOnBefore = false;
    public bool broken = false;
    public TextMeshProUGUI txtToDisplay;

    public AudioSource turnOn;
    public AudioSource turnOff;
    public AudioSource GlassBreak;

    private Light lampLight;

    void Start()
    {
        Trigger.SetActive(false);
        lampLight = GetComponent<Light>();
        lampLight.enabled = false;
        txtToDisplay.enabled = false;
        //GlobeMesh.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerInReach && !broken)
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
                turnedOnBefore = true;
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
            if (broken)
            {
                txtToDisplay.text = "Snow Globe is missing!";
                
            }
            else
            {
                txtToDisplay.text = "Turn on snow globe";
            }
                
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

    public void Break()
    {
 
        if(broken == false)
        {
            GlassBreak.Play();
        }
        broken = true;
        turnOn.Pause();
        lampLight.enabled = false;
        //GlobeMesh.enabled = false;
        txtToDisplay.text = "Snow Globe is missing!";
    }
}
