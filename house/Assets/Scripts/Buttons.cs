using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ALoadIntro()
    {
        SceneManager.LoadScene("intro");
    }

    public void AMainRoom()
    {
        SceneManager.LoadScene("test room");
    }

    public void ACredit()
    {
        SceneManager.LoadScene("credit");
    }

    public void ATitle()
    {
        SceneManager.LoadScene("title");
    }
}
