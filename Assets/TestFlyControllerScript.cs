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
    float horz_speed;
    float ver_speed;

    public string joystickHandleName = "CockpitEquipments_Joystick2-Handle"; // Name of the joystick handle object
    public float rollSpeed = 1.0f; // Roll speed multiplier
    public float pitchSpeed = 1.0f; // Pitch speed multiplier
    public float yawSpeed = 0.5f; // Yaw speed multiplier

    private Transform joystickHandle;
    GameObject throttle1,throttle2;

    // Start is called before the first frame update
    void Start()
    {
      joystickHandle = GameObject.Find(joystickHandleName).transform;
      throttle1 = GameObject.Find("CockpitEquipments_ThrottleControl1-Handle1");
      throttle2 = GameObject.Find("CockpitEquipments_ThrottleControl1-Handle2");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
	
    //GameObject throttle = GameObject.Find("CockpitEquipments_ThrottleControl1-Handle2");

    VG_Controller.GetObjectJointState(throttle1.transform, out jointState1);
    VG_Controller.GetObjectJointState(throttle2.transform, out jointState2);
    
	
    if (jointState1 < -30) {
		horz_speed = -1;
	}
	else if(jointState1 > 30) {
		horz_speed = 1;
	}
	else {
		horz_speed = 0;
	}    
	
	if (jointState2 < -30) {
		ver_speed = -1;
	}
	else if(jointState2 > 30) {
		ver_speed = 1;
	}
	else {
		ver_speed = 0;
	}
	

        transform.Translate(new Vector3(0, 0, 1) * speed * (jointState1/100.0f) * Time.deltaTime);

        transform.Translate(new Vector3(0, 0, -1) * speed * (jointState2/100.0f) * Time.deltaTime);
        
        //transform.Rotate(new Vector3(0, 0, 1) * speed * ver_speed * Time.deltaTime);
        //transform.Rotate(new Vector3(0, -1, 0) * speed * horz_speed * Time.deltaTime);
        
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
        transform.Rotate(Vector3.up, thirdAngle * yawSpeed * Time.deltaTime);

        // Update the spaceship's rotation based on the swing angle (pitch)
        transform.Rotate(Vector3.right, swingAngle * pitchSpeed * Time.deltaTime);

        // Update the spaceship's rotation based on the twist angle (roll)
        transform.Rotate(Vector3.forward, twistAngle * rollSpeed * Time.deltaTime);
     

    }
}
