using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleCarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    public Transform steerTransform;

    [SerializeField] private Animator steerAnim;

    private float initialRotationX, initialRotationY, initialRotationZ;
    private float motor, steering, turn;

    public void Start()
    {
        initialRotationX = steerTransform.localRotation.eulerAngles.x;
        initialRotationY = steerTransform.localRotation.eulerAngles.y;
        initialRotationZ = steerTransform.localRotation.eulerAngles.z;
    }

    private void Update()
    {
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = Input.GetAxis("Horizontal"); //-1 -> 1

        steerAnim.SetFloat("Steer", steering);

        turn = steering * maxSteeringAngle;
    }

    public void FixedUpdate()
    {
        
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = turn;
                axleInfo.rightWheel.steerAngle = turn;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }

        

        //steerTransform.localRotation = Quaternion.Euler(new Vector3(initialRotationX, initialRotationY + (40 * Input.GetAxis("Horizontal")), initialRotationZ));
        //steerTransform.localEulerAngles = new Vector3(20f + (Input.GetAxis("Horizontal")) * -5f, 180f + (Input.GetAxis("Horizontal") * 10f), (Input.GetAxis("Horizontal") * 90f));

    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}