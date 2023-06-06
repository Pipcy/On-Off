using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public GameObject TriggerImage;
    public bool PlayerInReach = false;
    public bool RadioOn = false;

    public AudioSource radioAudio;

    void Start()
    {
        TriggerImage.SetActive(false);
        radioAudio.Play();
        radioAudio.Pause();
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
            }
            else if(RadioOn == false)
            {
                RadioOn = true;
                radioAudio.Play();
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
