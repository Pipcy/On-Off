using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public TextMeshProUGUI timeText; // Reference to the UI text element to display the time
    public Button actionButton; // Reference to the button to activate when the time is up
    public AudioSource clock;

    private float elapsedTime; // Elapsed time in seconds
    private bool isTimeUp; // Flag indicating if the time is up

    private void Start()
    {
        elapsedTime = 0f;
        isTimeUp = false;
        UpdateTimeText();
        actionButton.interactable = false;
    }

    private void Update()
    {
        if (!isTimeUp)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= 3 * 60f)
            {
                elapsedTime = 3 * 60f;
                isTimeUp = true;
                timeText.text = "Your shift has ended, feel free to leave now.";
                actionButton.interactable = true;
                clock.Play();
                // Perform any desired actions when the time is up
            }

            UpdateTimeText();
        }
    }

    private void UpdateTimeText()
    {
        // Calculate the minutes and seconds from the elapsed time
        int minutes = Mathf.FloorToInt(9 + (elapsedTime / 60));
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        // Format the minutes and seconds into a string in the desired format
        string formattedTime = minutes.ToString("00") + ":" + seconds.ToString("00") + " pm";

        // Display the time or "Time is up!" in the UI text element
        timeText.text = isTimeUp ? "Your shift has ended. Click \"End Shift\" to leave." : formattedTime;
    }
}




