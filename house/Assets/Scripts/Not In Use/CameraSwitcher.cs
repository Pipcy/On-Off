//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Cinemachine;

//public static class CameraSwitcher
//{
//    static List<CinemachineVirtualCamera> VCams = new List<CinemachineVirtualCamera>();

//    public static CinemachineVirtualCamera ActiveCamera = null;

//    public static bool IsActiveCamera(CinemachineVirtualCamera VCam)
//    {
//        return VCam == ActiveCamera;
//    }

//    public static void SwitchCamera(CinemachineVirtualCamera VCam)
//    {
//        VCam.Priority = 10;
//        ActiveCamera = VCam;

//        foreach (CinemachineVirtualCamera c in VCams)
//        {
//            if(c != VCam && c.Priority != 0)
//            {
//                c.Priority = 0;
//            }
//        }
//    }

//    public static void Register(CinemachineVirtualCamera VCam)
//    {
//        VCams.Add(VCam);
//        Debug.Log("Vcam Registered: " + VCam);
//    }

//    public static void Unregister(CinemachineVirtualCamera VCam)
//    {
//        VCams.Remove(VCam);
//        Debug.Log("Vcam Unregistered: " + VCam);
//    }


//}
