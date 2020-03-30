using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{

    //variables
    public Transform PlayerTransform;
    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    //mouse controls
    public bool LookAtPlayer = false;
    public bool RotateAroundPlayer = true;
    public float RotationSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

        //set camera position
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //control camera direction and add mouse controls to rotate camera around player character
        if(RotateAroundPlayer)
        {

            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

            _cameraOffset = camTurnAngle * _cameraOffset;
        }

        Vector3 newPos = PlayerTransform.position + _cameraOffset;
        transform.position = Vector3.Slerp (transform.position, newPos, SmoothFactor);

        if (LookAtPlayer || RotateAroundPlayer)
        {

            transform.LookAt(PlayerTransform);
        }
    }
}
