using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Timeline : MonoBehaviour
{

    //overall
    private float timer;
    private bool isTimerRunning;

    //snow globe
    public MeshRenderer theGlobe;
    public SnowGlobe theGlobeScript;
    private float snowGlobetimer;
    private bool isSnowGlobeTimerRunning;
    public CameraTrigger CamLocation;

    //clock
    public AudioSource clock;
    public TextMeshProUGUI txt;
    public bool timeIsUp = false;
    public Buttons LeaveBtn;
   
    private void Start()
    {
        timer = 0f;
        isTimerRunning = true;
        snowGlobetimer = 0f;
        isSnowGlobeTimerRunning = false;

        txt.enabled = false;
        LeaveBtn.enabled = false;
    }

    private void Update()
    {
        //if (isTimerRunning)
        //{
        //    timer += Time.deltaTime;
        //    Debug.Log("All Timer: " + timer);
        //}

        //if(timer == 80)
        //{
        //    //sound 1
        //}
        //else if(timer == 120)
        //{
        //    //sound 2
        //}
        //else if (timer == 160)
        //{
        //    //sound 3
        //    //knocking
        //}
        //else if (timer > 10f)
        //{
            
        //    timeIsUp = true;
        //}
        //else if(timer == 300)
        //{
        //    SceneManager.LoadScene("credit");
        //}


        //if (timeIsUp)
        //{
        //    EndShift();
        //}

        //------------- check if snow globe has been turned on ----------
        if (isSnowGlobeTimerRunning)
        {
            snowGlobetimer += Time.deltaTime;
            //Debug.Log("Timer: " + snowGlobetimer);
        }

        if (theGlobeScript.turnedOnBefore)
        {
            isSnowGlobeTimerRunning = true;
        }

        if (snowGlobetimer > 10 && !CamLocation.inBathroom)
        {
            //theGlobe.enabled = false;
            Debug.Log("Break!");
            isSnowGlobeTimerRunning = false;
            theGlobeScript.Break();
            
        }

        
    }

    void EndShift()
    {
        clock.Play();
        //txt.enabled = true;
        txt.text = "It's 12 am, your shift has ended.";
        LeaveBtn.enabled = true;
    }
}

