using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Photo : MonoBehaviour
{
    public GameObject Trigger;
    public Image photo;
    public TextMeshProUGUI hint;
    public bool isTrash;
    public bool PlayerInReach = false;
    public bool On = false;

    

    void Start()
    {
        Trigger.SetActive(false);
        photo.enabled = false;
        hint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerInReach)
        {
            if (On)
            {
                On = false;
                photo.enabled = false;
                hint.enabled = false;
            }
            else if (On == false)
            {
                
                On = true;
                photo.enabled = true;
                if (isTrash)
                {
                    hint.enabled = true;
                    hint.text = "Press U to clean up broken pieces.";
                }


            }
        }

        if (Input.GetKeyDown(KeyCode.U) && isTrash)
        {
            hint.enabled = false;
            photo.enabled = false;
            gameObject.SetActive(false);
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
