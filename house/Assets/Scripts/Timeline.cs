using UnityEngine;

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
   
    private void Start()
    {
        timer = 0f;
        isTimerRunning = true;
        snowGlobetimer = 0f;
        isSnowGlobeTimerRunning = false;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            timer += Time.deltaTime;
            //Debug.Log("Timer: " + timer);
        }

        //------------- check if snow globe has been turned on ----------
        if (isSnowGlobeTimerRunning)
        {
            snowGlobetimer += Time.deltaTime;
            Debug.Log("Timer: " + snowGlobetimer);
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
}

