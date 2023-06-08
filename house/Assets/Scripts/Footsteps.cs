using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource[] footstepSounds; // Array of footstep audio sources
    public float interval = 0.5f; // Time between each footstep sound
    private bool isWalking = false;

    private float timer = 0f; // Timer to track the interval

    //private void Start()
    //{
    //    isWalking = GetComponent<PlayerAnimStage>().walking;
    //}

    private void Update()
    {
        //Debug.Log(GetComponent<PlayerAnimStage>().walking);
        if (GetComponent<PlayerAnimStage>().walking)
        {
            // Update the timer
            timer += Time.deltaTime;

            // Check if enough time has passed to play the next footstep sound
            if (timer >= interval)
            {
                PlayFootstepSound();
                timer = 0f; // Reset the timer
            }
        }
    }

    // Method to play a random footstep sound from the array
    private void PlayFootstepSound()
    {
        if (footstepSounds.Length == 0)
        {
            Debug.LogWarning("No footstep sounds assigned.");
            return;
        }

        int randomIndex = Random.Range(0, footstepSounds.Length);
        footstepSounds[randomIndex].Play();
    }

    //// Method to start walking
    //public void StartWalking()
    //{
    //    isWalking = true;
    //}

    //// Method to stop walking
    //public void StopWalking()
    //{
    //    isWalking = false;
    //}
}
