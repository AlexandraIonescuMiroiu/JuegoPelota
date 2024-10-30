using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineTransposer cineTransposer;

    public enum CameraPosition { Front, Left, Right, Back }
    [SerializeField] private CameraPosition cameraPosition;

    void Start()
    {
        if (virtualCamera == null)
        {
            Debug.LogError("Virtual camera not set.");
            return;
        }

        cineTransposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        if (cineTransposer == null)
        {
            Debug.LogError("CinemachineTransposer not found on the virtual camera.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (cameraPosition)
            {
                case CameraPosition.Front:
                    SetCameraPosition(new Vector3(0, 2, -5));
                    Debug.Log("Setting camera to Front");
                    break;
                case CameraPosition.Left:
                    SetCameraPosition(new Vector3(5, 2, 0));
                    Debug.Log("Setting camera to Left");
                    break;
                case CameraPosition.Right:
                    SetCameraPosition(new Vector3(-5, 2, 0));
                    Debug.Log("Setting camera to Right");
                    break;
                case CameraPosition.Back:
                    SetCameraPosition(new Vector3(0, 2, 5));
                    Debug.Log("Setting camera to Back");
                    break;
            }
        }
    }

    public void SetCameraPosition(Vector3 newPosition)
    {
        cineTransposer.m_FollowOffset = newPosition;
    }
}
