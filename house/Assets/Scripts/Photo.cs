using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Photo : MonoBehaviour
{
    public GameObject Trigger;
    public Image[] photos;
    public TextMeshProUGUI hint;
    public bool isKey;
    public bool PlayerInReach = false;
    public bool On = false;
    public bool picked = false;
    public DoorController bathroomDoor;

    

    void Start()
    {
        Trigger.SetActive(false);
        foreach(Image photo in photos)
        {
            photo.enabled = false;
        }
        
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
                foreach (Image photo in photos)
                {
                    photo.enabled = false;
                }
                hint.enabled = false;
            }
            else if (On == false)
            {
                
                On = true;
                foreach (Image photo in photos)
                {
                    photo.enabled = true;
                }
                if (isKey)
                {
                    hint.enabled = true;
                    hint.text = "Press U to pick up bathroom key";
                }


            }
        }

        if (Input.GetKeyDown(KeyCode.U) && isKey)
        {
            picked = true;
            hint.enabled = false;
            foreach (Image photo in photos)
            {
                photo.enabled = false;
            }
            gameObject.SetActive(false);

            bathroomDoor.gotKey = true;
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
