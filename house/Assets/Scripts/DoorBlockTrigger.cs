using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorBlockTrigger : MonoBehaviour
{
    public TextMeshProUGUI hinttext;
    
    void Start()
    {
        hinttext.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("player");
        if (other.CompareTag("Player"))
        {
            hinttext.enabled = true;
            hinttext.text = "My shift have not ended yet, I must stay in the house.";
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hinttext.enabled = false;
        }
    }
}
