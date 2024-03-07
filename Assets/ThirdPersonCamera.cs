using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float sensitivity;
    [SerializeField] private float verticalRotationMin, verticalRotationMax;
    [SerializeField] private float cameraZoom;
    [SerializeField] private LayerMask avoidLayer;
    private float idealcameraZoom;
    private float currentCameraZoom;
    private float currentHorizontalRotation, currentVerticalRotation;
    private Transform cameraTransform, boomTransform;
    // Start is called before the first frame update
    void Start()
    {
        boomTransform = transform.GetChild(0);
        cameraTransform = boomTransform.GetChild(0);
        currentHorizontalRotation = transform.localEulerAngles.y;
        currentVerticalRotation = boomTransform.localEulerAngles.x;
        Cursor.visible = false;

    }
    
    // Update is called once per frame
    void Update()
    {
        currentHorizontalRotation += Input.GetAxis("Mouse X")  * sensitivity;
        currentVerticalRotation += Input.GetAxis("Mouse Y") * sensitivity;
        currentVerticalRotation = Mathf.Clamp(currentVerticalRotation, verticalRotationMin, verticalRotationMax);
        transform.localEulerAngles = new Vector3(0, currentHorizontalRotation);
        boomTransform.localEulerAngles = new Vector3 (currentVerticalRotation,0,0);
        transform.position = playerTransform.position;

        Vector3 directionToCamera = cameraTransform.position - playerTransform .position;
        directionToCamera.Normalize();
        if (Physics.Raycast(playerTransform.position,directionToCamera, out RaycastHit hit, cameraZoom, avoidLayer))
        {
            currentCameraZoom = hit.distance;
        }
        else
        {
            currentCameraZoom = cameraZoom;
        }
        cameraTransform.localPosition = new Vector3(0, 0, -currentCameraZoom);
    }
}
