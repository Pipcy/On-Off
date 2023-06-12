using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * Tasks:
 * 1. turn on all 4 lamps.
 * 2. Play music from the antique music recorder.
 * 3. Try to play radio.
 * 4. Sit on sofa to watch TV.
 * 5. Find bathroom key.
 * 6. Play with Mrs.Hopkins' Snow Globe
 * 7. Try laying on the bed.
 */

public class TaskPanel : MonoBehaviour
{
    [Header("Task 1")]
    public TextMeshProUGUI txt1;
    public light lamp1;
    public light lamp2;
    public light lamp3;
    public light lamp4;
    public bool L1 = false;
    public bool L2 = false;
    public bool L3 = false;
    public bool L4 = false;

    public int turned = 0;
    

    [Header("Task 2")]
    public TextMeshProUGUI txt2;
    public Radio recordPlayer;
    public bool musicPlayed = false;

    [Header("Task 3")]
    public TextMeshProUGUI txt3;
    public Radio radio;
    public bool radioPlayed = false;

    [Header("Task 4")]
    public TextMeshProUGUI txt4;
    public Radio TV;
    public PlayerAnimStage playerSat;
    public bool TVPlayed = false;

    [Header("Task 5")]
    public TextMeshProUGUI txt5;
    public Photo key;
    public bool keyPicked = false;


    [Header("Task 6")]
    public TextMeshProUGUI txt6;
    public SnowGlobe globe;
    public bool GlobePlayed = false;

    [Header("Task 7")]
    public TextMeshProUGUI txt7;
    public textOnly bed;
    public bool bedTried = false;


    void Start()
    {

    }


    void Update()
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
        Task7();
    }


    void Task1()
    {
        txt1.enabled = true;
        txt1.text = "1. Turn on all four lights. (" + turned + "/4)";

        if(turned == 4)
        {
            txt1.text = "<s>" + "1. Turn on all four lights. (" + turned + "/4)" + "</s>";
        }

        if(L1 == false)
        {
            if (lamp1.turnedOn)
            {
                turned++;
                L1 = true;
            }
        }

        if (L2 == false)
        {
            if (lamp2.turnedOn)
            {
                turned++;
                L2 = true;
            }
        }

        if (L3 == false)
        {
            if (lamp3.turnedOn)
            {
                turned++;
                L3 = true;
            }
        }

        if (L4 == false)
        {
            if (lamp4.turnedOn)
            {
                turned++;
                L4 = true;
            }
        }
    }

    void Task2()
    {
        txt2.enabled = true;
        
        if (musicPlayed)
        {
            txt2.text = "<s>2. Play music from the antique record player.</s>";
        }
        else
        {
            txt2.text = "2. Play music from the antique music recorder.";
        }

        if (recordPlayer.turnedOn)
        {
            musicPlayed = true;
        }
    }

    void Task3()
    {
        txt3.enabled = true;
       
        if (radioPlayed)
        {
            txt3.text = "<s>3. Try to play the radio.</s>";
        }
        else
        {
            txt3.text = "3. Try to play the radio.";
        }

        if (radio.turnedOn)
        {
            radioPlayed = true;
        }
    }

    void Task4()
    {
        txt4.enabled = true;

        if (TVPlayed)
        {
            txt4.text = "<s>4. Sit on sofa to watch TV.</s>";
        }
        else
        {
            txt4.text = "4. Sit on sofa to watch TV.";
        }

        if (TV.RadioOn && playerSat.sat)
        {
            TVPlayed = true;
        }
    }

    void Task5()
    {
        txt5.enabled = true;

        if (keyPicked)
        {
            txt5.text = "<s>5. Find bathroom key.</s>";
        }
        else
        {
            txt5.text = "5. Find bathroom key.";
        }

        if (key.picked)
        {
            keyPicked = true;
        }
    }

    void Task6()
    {
        txt6.enabled = true;

        if (GlobePlayed)
        {
            txt6.text = "<s>6. Play with Mrs.Hopkins' Snow Globe.</s>";
        }
        else
        {
            txt6.text = "6. Play with Mrs.Hopkins' Snow Globe.";
        }

        if (globe.turnedOnBefore)
        {
            GlobePlayed = true;
        }
    }

    void Task7()
    {
        txt7.enabled = true;

        if (bedTried)
        {
            txt7.text = "<s>7. Try laying on the bed.</s>";
        }
        else
        {
            txt7.text = "7. Try laying on the bed.";
        }

        if (bed.tried)
        {
            bedTried = true;
        }
    }
}



