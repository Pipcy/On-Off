using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public float lineDelay = 1f; // Delay between each line

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(DisplayLines());
    }

    IEnumerator DisplayLines()
    {
        foreach (string line in lines)
        {
            //yield return new WaitForSeconds(lineDelay); // Delay before displaying the next line
            yield return StartCoroutine(TypeLine(line));
            yield return new WaitForSeconds(lineDelay); // Delay after displaying the line
            NextLine();
            textComponent.text += "<br>";
        }

        // All lines have been displayed
        gameObject.SetActive(false);
        
    }

    IEnumerator TypeLine(string line)
    {
        // Clear previous text
        textComponent.text = string.Empty;

        // Type each character one by one
        foreach (char c in line.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}