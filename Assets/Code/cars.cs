using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class cars : MonoBehaviour
{

    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        float motor = 0f;
        if (Input.GetAxis("Vertical") > 0f) // yön tuþlarýna basýlýysa
        {
            motor = maxMotorTorque * Input.GetAxis("Vertical");
        }

        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        // Aracýn durdurma iþlemi
        if (Input.GetKeyDown(KeyCode.Space))
        {
            motor = 0f;
            steering = 0f;
        }

        ////Geri viteste deðilken aracýn hareket etmesini saðlama
        //if (motor == 0f)
        //{
        //    foreach (AxleInfo axleInfo in axleInfos)
        //    {
        //        if (axleInfo.motor)
        //        {
        //            axleInfo.leftWheel.brakeTorque = maxMotorTorque;
        //            axleInfo.rightWheel.brakeTorque = maxMotorTorque;
        //        }
        //    }
        //}
        else
        {
            foreach (AxleInfo axleInfo in axleInfos)
            {
                if (axleInfo.motor)
                {
                    axleInfo.leftWheel.brakeTorque = 0f;
                    axleInfo.rightWheel.brakeTorque = 0f;
                }
            }
        }

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

}