//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Cinemachine;

//public class CameraAndPlayer : MonoBehaviour
//{
//    [SerializeField] CinemachineVirtualCamera LivingRoomCam;
//    [SerializeField] CinemachineVirtualCamera BathRoomCam;

//    private void OnEnable()
//    {
//        CameraSwitcher.Register(LivingRoomCam);
//        CameraSwitcher.Register(BathRoomCam);
//        CameraSwitcher.SwitchCamera(LivingRoomCam);
//    }

//    private void OnDisable()
//    {
//        CameraSwitcher.Unregister(LivingRoomCam);
//        CameraSwitcher.Unregister(BathRoomCam);
//    }

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            //Switch camera
//            if (CameraSwitcher.IsActiveCamera(LivingRoomCam))
//            {
//                CameraSwitcher.SwitchCamera(BathRoomCam);
//            }
//            else if (CameraSwitcher.IsActiveCamera(BathRoomCam))
//            {
//                CameraSwitcher.SwitchCamera(LivingRoomCam);
//            }
//        }
//    }
//}
