using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VirtualGrasp;

public class TestFlyControllerScript : MonoBehaviour
{

    [SerializeField]
    float speed;

    float jointState1;
    float jointState2;

    public string joystickHandleName = "CockpitEquipments_Joystick2-Handle"; // Name of the joystick handle object
    public float rollSpeed = 0.5f; // Roll speed multiplier
    public float pitchSpeed = 0.5f; // Pitch speed multiplier
    public float yawSpeed = 0.5f; // Yaw speed multiplier

    private Transform joystickHandle;
    GameObject throttle1,throttle2;

    // Start is called before the first frame update
    void Start()
    {
      joystickHandle = GameObject.Find(joystickHandleName).transform;
      throttle1 = GameObject.Find("CockpitEquipments_ThrottleControl1-Handle2");
	  VG_Controller.SetObjectJointState(throttle1.transform, -30.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
	
    //GameObject throttle = GameObject.Find("CockpitEquipments_ThrottleControl1-Handle2");

    VG_Controller.GetObjectJointState(throttle1.transform, out jointState1);

        transform.Translate(new Vector3(0, 0, 1) * speed * ((jointState1+30.0f)/100.0f) * Time.fixedDeltaTime);
        
        //transform.Rotate(new Vector3(0, 0, 1) * speed * ver_speed * Time.fixedDeltaTime);
        //transform.Rotate(new Vector3(0, -1, 0) * speed * horz_speed * Time.fixedDeltaTime);
        
    float swingAngle = joystickHandle.localEulerAngles.x;
    float twistAngle = joystickHandle.localEulerAngles.z;
    float thirdAngle = joystickHandle.localEulerAngles.y;

        // Convert the swing angle to a value between -180 and 180 degrees
        if (swingAngle > 180)
        {
            swingAngle -= 360;
        }

        // Convert the twist angle to a value between -180 and 180 degrees
        if (twistAngle > 180)
        {
            twistAngle -= 360;
        }
        if (thirdAngle > 180)
        {
            thirdAngle -= 360;
        }

        // Update the spaceship's rotation based on the twist angle (yaw)
        transform.Rotate(Vector3.up, thirdAngle * yawSpeed * Time.fixedDeltaTime);

        // Update the spaceship's rotation based on the swing angle (pitch)
        transform.Rotate(Vector3.right, swingAngle * pitchSpeed * Time.fixedDeltaTime);

        // Update the spaceship's rotation based on the twist angle (roll)
        transform.Rotate(Vector3.forward, twistAngle * rollSpeed * Time.fixedDeltaTime);
     

    }
}
