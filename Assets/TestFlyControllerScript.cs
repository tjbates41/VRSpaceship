using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VirtualGrasp;

public class TestFlyControllerScript : MonoBehaviour
{

    [SerializeField]
    float thruster_speed;

    [SerializeField]
    float rotateSpeed;

    private float throttle_left_jointState;
	private float throttle_right_jointState;
	private float horz_direction;
	private float vert_direction;
	
	//private Rigidbody rb;
	private GameObject throttle_left;
	private GameObject throttle_right;

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
      throttle_left = GameObject.Find("CockpitEquipments_ThrottleControl1-Handle2");
	  throttle_right = GameObject.Find("CockpitEquipments_ThrottleControl1-Handle1");
    }

    // Update is called once per frames
    void FixedUpdate()
    {
	
    //GameObject throttle = GameObject.Find("CockpitEquipments_ThrottleControl1-Handle2");

    VG_Controller.GetObjectJointState(throttle_left.transform, out throttle_left_jointState);
	VG_Controller.GetObjectJointState(throttle_right.transform, out throttle_right_jointState);
    
	
    if (throttle_left_jointState < -15 && throttle_right_jointState < -15) { // backwards
			horz_direction = 0;
			vert_direction = -1;
		}
		else if(throttle_left_jointState > 15 && throttle_right_jointState > 15) { // forwards
			horz_direction = 0;
			vert_direction = 1;
		}
		else if(throttle_left_jointState > 15 && throttle_right_jointState < 15 && throttle_right_jointState > -15) { // turn right
			horz_direction = -1;
			vert_direction = 0;
		}
		else if(throttle_left_jointState > 15 && throttle_right_jointState < -15) { // turn right faster
			horz_direction = -2;
			vert_direction = 0;
		}
		else if(throttle_right_jointState > 15 && throttle_left_jointState < 15 && throttle_left_jointState > -15) { // turn left
			horz_direction = 1;
			vert_direction = 0;
		}
		else if(throttle_right_jointState > 15 && throttle_left_jointState < -15) { // turn left faster
			horz_direction = 2;
			vert_direction = 0;
		}
		else if(throttle_left_jointState < -15 && throttle_right_jointState < 15 && throttle_right_jointState > -15) { // turn left
			horz_direction = 1;
			vert_direction = 0;
		}
		else if(throttle_right_jointState < -15 && throttle_left_jointState < 15 && throttle_left_jointState > -15) { // turn right
			horz_direction = -1;
			vert_direction = 0;
		}
		else {
			horz_direction = 0;
			vert_direction = 0;
		}

        transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * horz_direction * Time.deltaTime);
		transform.Translate(new Vector3(0, 0, -1) * thruster_speed * vert_direction * Time.deltaTime);
        
    float swingAngle = joystickHandle.localEulerAngles.x;
    //float twistAngle = joystickHandle.localEulerAngles.z;
    float thirdAngle = joystickHandle.localEulerAngles.y;

        // Convert the swing angle to a value between -180 and 180 degrees
        if (swingAngle > 180)
        {
            swingAngle -= 360;
        }

        // Convert the twist angle to a value between -180 and 180 degrees
        /*
        if (twistAngle > 180)
        {
            twistAngle -= 360;
        }
        if (thirdAngle > 180)
        {
            thirdAngle -= 360;
        }
        */
        // Update the spaceship's rotation based on the twist angle (yaw)
        transform.Rotate(Vector3.up, thirdAngle * yawSpeed * Time.deltaTime);

        // Update the spaceship's rotation based on the swing angle (pitch)
        transform.Rotate(Vector3.right, swingAngle * pitchSpeed * Time.deltaTime);

        // Update the spaceship's rotation based on the twist angle (roll)
    //#transform.Rotate(Vector3.forward, twistAngle * rollSpeed * Time.deltaTime);
     

    }
}
