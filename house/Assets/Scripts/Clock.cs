using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public string content;

    //public GameObject trigger;
    public AudioSource ClockAudio;
    public bool timeIsUp;
    public bool tried = false;

    void Start()
    {
        txt.enabled = false;
        
        
    }

    private void Update()
    {
        if (timeIsUp)
        {
            txt.enabled = true;
            txt.text = content;
            ClockAudio.Play();
            
        }
    }

}
