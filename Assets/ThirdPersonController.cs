using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : CustomController
{
    [SerializeField] private Transform cameraTransform;
    protected override void Move(Vector3 direction)
    {
        direction = cameraTransform.TransformDirection(direction);
        if (direction.magnitude > 0.1f)
        {
            Vector3 facingDirection = new Vector3(direction.x, 0, direction.z);
            transform.forward = facingDirection;
        }

        base.Move(direction);
    }
    
}
