using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwapper : MonoBehaviour
{
    [SerializeField] private Camera firstPersonCamera;
    [SerializeField] private Camera thirdPersonCamera;
    [SerializeField] private FirstPersonController firstPersonController;
    [SerializeField] private ThirdPersonController thirdPersonController;
    // Start is called before the first frame update
    public enum CameraMode
    {
        FirstPerson,
        ThirdPerson
    }
    [SerializeField] private CameraMode currentcameraMode;
    private void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
        thirdPersonController = GetComponent<ThirdPersonController>();

        firstPersonCamera = FindObjectOfType<FirstPersonCamera>().GetComponent<Camera>();
        thirdPersonCamera = FindObjectOfType<ThirdPersonCamera>().GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SetCamera();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCamera();
        }
    }
    private void ToggleCamera()
    {
        if (currentcameraMode == CameraMode.FirstPerson)
        {
            currentcameraMode = CameraMode.ThirdPerson;
        }
        else
        {
            currentcameraMode = CameraMode.FirstPerson;
        }
        SetCamera();
    }
    private void SetCamera()
    {
        switch (currentcameraMode)
        {
            case CameraMode.FirstPerson:
                firstPersonCamera.depth = 0;
                firstPersonController.enabled = true;
                thirdPersonCamera.depth = -1;
                thirdPersonController.enabled = false;
                break;
            case CameraMode.ThirdPerson:
                thirdPersonCamera.depth= 0;
                thirdPersonController.enabled = true;
                firstPersonCamera.depth=-1;
                firstPersonController.enabled = false;
                break;

        }
    }
}
