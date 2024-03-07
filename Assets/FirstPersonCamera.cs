using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private float verticalRotationMin, verticalRotationMax;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float playerEyeLevel = 0.5f;
    private float currenHorizontalRotation, currenVerticalRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        currenHorizontalRotation = transform.localEulerAngles.y;
        currenVerticalRotation = transform.localEulerAngles.y;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        currenHorizontalRotation += Input.GetAxis("Mouse X") * sensitivity;
        currenVerticalRotation -= Input.GetAxis ("Mouse Y") * sensitivity;
        currenVerticalRotation = Mathf.Clamp(currenVerticalRotation, verticalRotationMin, verticalRotationMax);

        transform.localEulerAngles = new Vector3(currenVerticalRotation, currenHorizontalRotation);
        transform.position = playerTransform.position + (Vector3.up * playerEyeLevel);
        
    }

}
