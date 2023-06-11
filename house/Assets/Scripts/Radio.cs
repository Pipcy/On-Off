using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public GameObject TriggerImage;
    public GameObject screen = null;
    public bool PlayerInReach = false;
    public bool RadioOn = false;
    public bool turnedOn = false;
    public bool isTV;

    public AudioSource radioAudio;
    public AudioSource turnOn;
    public AudioSource turnOff;

    void Start()
    {
        TriggerImage.SetActive(false);
        radioAudio.Play();
        radioAudio.Pause();
        screen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerInReach)
        {
            if (RadioOn)
            {
                RadioOn = false;
                radioAudio.Pause();
                turnOff.Play();
                if(isTV)
                    screen.SetActive(false);
            }
            else if(RadioOn == false)
            {
                turnedOn = true;
                RadioOn = true;
                
                radioAudio.Play();
                if(isTV)
                    screen.SetActive(true);
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
            TriggerImage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //show trigger Image
            PlayerInReach = false;
            TriggerImage.SetActive(false);
        }
    }
}
