using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayAndSceneSwitch : MonoBehaviour
{
    public AudioClip audioClip;
    public string sceneName;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayAudioAndSwitchScene());
    }

    private IEnumerator PlayAudioAndSwitchScene()
    {
        yield return new WaitForSeconds(3f);

        //audioSource.clip = audioClip;
        //audioSource.Play();

        yield return new WaitForSeconds(audioClip.length-10);

        SceneManager.LoadScene("test room");
    }
}

