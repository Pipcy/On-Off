using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayAndSceneSwitch : MonoBehaviour
{
    public AudioClip audioClip;
    public string sceneName;
    private float time;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayAudioAndSwitchScene());
        time = audioClip.length-15;
    }

    private IEnumerator PlayAudioAndSwitchScene()
    {
        yield return new WaitForSeconds(3f);

        //audioSource.clip = audioClip;
        //audioSource.Play();
        
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene("test room");
    }
}

