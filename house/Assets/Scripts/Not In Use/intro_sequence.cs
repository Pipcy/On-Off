using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class intro_sequence : MonoBehaviour
{
    //public  textComponent;
    public TextMeshProUGUI[] lines;
    public float textSpeed;
    public float lineDelay = 1f; // Delay between each line

    private int index;

    void Start()
    {
        //textComponent.text = string.Empty;
        StartDialogue();
        foreach(TextMeshProUGUI line in lines)
        {
            line.enabled = false;
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(DisplayLines());
    }

    IEnumerator DisplayLines()
    {
        foreach (TextMeshProUGUI line in lines)
        {
            yield return StartCoroutine(TypeLine(line));
            yield return new WaitForSeconds(lineDelay); // Delay after displaying the line
            NextLine(line);
            //textComponent.text += "<br>";
        }

        // All lines have been displayed
        gameObject.SetActive(false);
    }

    IEnumerator TypeLine(TextMeshProUGUI line)
    {
        line.enabled = true;
        yield break;

    }

    void NextLine(TextMeshProUGUI line)
    {
        if (index < lines.Length - 1)
        {
            index++;
            line.enabled = false;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}