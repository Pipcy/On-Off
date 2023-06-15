//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Cinemachine;

//public class CameraTrigger : MonoBehaviour
//{
//    //----------for camera
//    public List<CinemachineVirtualCamera> VCams;

//    //public CinemachineVirtualCamera CurrentCam;
//    public CinemachineBrain cinemachineBrain;


//    //----------for walls
//    public GameObject Wall0;
//    public GameObject Wall1;
//    public GameObject Wall2;
//    public GameObject Wall3;
//    public GameObject Wall4;
//    private MeshRendererSwitcher MeshSwitch;

//    private void Start()
//    {
//        MeshSwitch = GetComponent<MeshRendererSwitcher>();

//        HideWalls(Wall0);
//        HideWalls(Wall1);
//        //MeshSwitch.DisableChildMeshRenderers(Wall1);
//        //MeshSwitch.DisableChildMeshRenderers(Wall2);
//        //MeshSwitch.EnableChildMeshRenderers(Wall0);
//        //MeshSwitch.EnableChildMeshRenderers(Wall3);
//    }


//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("zoneA"))
//        {
//            Debug.Log("Player in Zone A");
//            CamSwitchTo(VCams[0]);
//            //HideWalls(Wall1);
//            //HideWalls(Wall2);
//            //ShowThen(Wall0, Wall3);
//        }
//        else if (other.CompareTag("zoneB"))
//        {
//            Debug.Log("Player in Zone B");
//            CamSwitchTo(VCams[1]);
//            //HideWalls(Wall1);
//            //HideWalls(Wall3);
//            //ShowThen(Wall0, Wall2);
//        }
//        else if (other.CompareTag("zoneC"))
//        {
//            Debug.Log("Player in Zone C");
//            CamSwitchTo(VCams[2]);
//            //HideWalls(Wall0);
//            //HideWalls(Wall3);
//            //ShowThen(Wall1, Wall2);
//        }
//        else if (other.CompareTag("zoneD"))
//        {
//            Debug.Log("Player in Zone D");
//            CamSwitchTo(VCams[3]);
//            //HideWalls(Wall0);
//            //HideWalls(Wall2);
//            //ShowThen(Wall1, Wall3);
//        }
//        else if (other.CompareTag("zoneE"))// bathroom
//        {
//            Debug.Log("Player in Zone E");
//            CamSwitchTo(VCams[4]);
//        }
//    }

//    void CamSwitchTo(CinemachineVirtualCamera TargetCam)
//    {
//        //CurrentCam = TargetCam;
//        foreach (CinemachineVirtualCamera c in VCams)
//        {
//            c.Priority = 0;
//        }

//        TargetCam.Priority = 10;

//    }


//    private void Update()
//    {
//        //Debug.Log(CinemachineCore.Instance.IsLive(CurrentCam));
//        Debug.Log(cinemachineBrain.IsBlending);

//        bool CamMoving = cinemachineBrain.IsBlending;
//    }

//    void ShowThen(params GameObject[] walls)
//    {
//        if (cinemachineBrain.IsBlending == false)
//        {
//            foreach(GameObject wall in walls)
//            {
//                ShowWalls(wall);
//            }
//        }
//    }

//    void ShowWalls(GameObject activeWall)
//    {
//        MeshSwitch.EnableChildMeshRenderers(activeWall);
//    }

//    void HideWalls(GameObject inactiveWall)
//    {
//        MeshSwitch.DisableChildMeshRenderers(inactiveWall);
//    }



//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTrigger : MonoBehaviour
{
    //----------for camera
    public List<CinemachineVirtualCamera> VCams;

    //public CinemachineVirtualCamera CurrentCam;
    public CinemachineBrain cinemachineBrain;


    public Transform[] waypoints;
    int currentWaypointIndex;
    public Camera MainCam;


    //----------for walls
    public GameObject Wall0;
    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject WallB1;//bathroom wall
    public GameObject WallB2;//bathroom wall
    //private MeshRendererSwitcher MeshSwitch;

    //-----
    public bool inBathroom = false;

    private void Start()
    {
        //MeshSwitch = GetComponent<MeshRendererSwitcher>();

        HideWalls(Wall0);
        HideWalls(Wall3);
        ShowWalls(Wall1);
        ShowWalls(Wall2);

        HideWalls(WallB1);
        HideWalls(WallB2);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("zoneA"))
        {
            Debug.Log("Player in Zone A");
            currentWaypointIndex = 0;
            CamSwitchTo(VCams[0]);
            HideWalls(Wall1);
            HideWalls(Wall2);
            //ShowThen(Wall0, Wall3);

        }
        else if (other.CompareTag("zoneB"))
        {
            Debug.Log("Player in Zone B");
            currentWaypointIndex = 1;
            CamSwitchTo(VCams[1]);
            HideWalls(Wall1);
            HideWalls(Wall3);
            //ShowThen(Wall0, Wall2);
        }
        else if (other.CompareTag("zoneC"))
        {
            Debug.Log("Player in Zone C");
            currentWaypointIndex = 2;
            CamSwitchTo(VCams[2]);
            HideWalls(Wall0);
            HideWalls(Wall3);
            //ShowThen(Wall1, Wall2);
        }
        else if (other.CompareTag("zoneD"))
        {
            Debug.Log("Player in Zone D");
            currentWaypointIndex = 3;
            CamSwitchTo(VCams[3]);
            HideWalls(Wall0);
            HideWalls(Wall2);
            //ShowThen(Wall1, Wall3);
        }
        else if (other.CompareTag("zoneE"))// bathroom
        {
            inBathroom = true;
            Debug.Log("Player in Zone E");
            currentWaypointIndex = 4;
            CamSwitchTo(VCams[4]);
            HideWalls(Wall0);
            HideWalls(Wall1);
            HideWalls(Wall2);
            HideWalls(Wall3);

            //show bathroom walls imediately
            ShowWalls(WallB1);
            ShowWalls(WallB2);

        }

        if (other.CompareTag("zoneA"))// bathroom
        {
            inBathroom = false;
            HideWalls(WallB1);
            HideWalls(WallB2);
            
        }

        //special camera
        if (other.CompareTag("SnowGlobe"))// snow globe
        {
            CamSwitchTo(VCams[5]);
        }
        else if(other.CompareTag("ExitDoor"))// exit door
        {
            CamSwitchTo(VCams[6]);
        }
    }

    void CamSwitchTo(CinemachineVirtualCamera TargetCam)
    {
        //CurrentCam = TargetCam;
        foreach (CinemachineVirtualCamera c in VCams)
        {
            c.Priority = 0;
        }

        TargetCam.Priority = 10;

    }


    private void Update()
    {
        
        float point_cam_dis = Vector3.Distance(MainCam.transform.position, waypoints[currentWaypointIndex].position);
        //Debug.Log(point_cam_dis);// + "CurrentWaypointIndex: " + currentWaypointIndex);
        //Debug.Log("Cam Loc: " + MainCam.transform.position);
        //Debug.Log("WP: " + currentWaypointIndex +" WP LOC: " + waypoints[currentWaypointIndex].position);

        if (point_cam_dis <= 5f)
        {
            //Debug.Log("here");
            if (currentWaypointIndex == 3)
            {
                ShowWalls(Wall1);
                ShowWalls(Wall3);
            }
            else if (currentWaypointIndex == 1)
            {
                ShowWalls(Wall0);
                ShowWalls(Wall2);
            }
            else if (currentWaypointIndex == 2)
            {
                ShowWalls(Wall1);
                ShowWalls(Wall2);
            }
            else if (currentWaypointIndex == 0)
            {
                ShowWalls(Wall0);
                ShowWalls(Wall3);
            }
            else if (currentWaypointIndex == 4)
            {
                ShowWalls(WallB1);
                ShowWalls(WallB2);
            }

        }
    }

    void ShowWalls(GameObject Wall)
    {
        Wall.GetComponent<MeshRenderer>().enabled = true;
        //MeshSwitch.EnableChildMeshRenderers(activeWall);
    }

    void HideWalls(GameObject Wall)
    {
        Wall.GetComponent<MeshRenderer>().enabled = false;
        //MeshSwitch.DisableChildMeshRenderers(inactiveWall);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SnowGlobe"))// bathroom
        {
            CamSwitchTo(VCams[4]);
        }
        else if (other.CompareTag("ExitDoor"))// zone C
        {
            CamSwitchTo(VCams[2]);
        }
    }



}