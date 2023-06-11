using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textOnly : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public string content;

    public TextMeshProUGUI txt2;
    public string content2;

    public GameObject trigger;
    public AudioSource triggerAudio;
    public bool PlayerInReach = false;
    public bool tried;

    void Start()
    {
        txt.enabled = false;
        txt2.enabled = false;
        trigger.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerInReach)
        {
            txt2.enabled = true;
            txt2.text = content2;
            triggerAudio.Play();
            tried = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            PlayerInReach = true;
            txt.enabled = true;
            txt.text = content;
            trigger.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInReach = false;
            txt.enabled = false;
            txt2.enabled = false;
            trigger.SetActive(false);
        }
    }
}
