using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VirtualGrasp;

public class TestFlyControllerScript : MonoBehaviour
{

    [SerializeField]
    float rotateSpeed;

    [SerializeField]
    float turnSpeed;

    [SerializeField]
    float speed;

    [SerializeField]
    float downAndUpSpeed;

    float throttle_left_jointState;
    float thruster_speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
	
    	GameObject throttle_left = GameObject.Find("CockpitEquipments_ThrottleControl1-Handle2");
	GameObject throttle_right = GameObject.Find("CockpitEquipments_ThrottleControl1-Handle1");

	
	VG_Controller.GetObjectJointState(throttle_left.transform, out throttle_left_jointState);
	if (throttle_left_jointState < -30) {
		thruster_speed = -1;
	}
	else if(throttle_left_jointState > 30) {
		thruster_speed = 1;
	}
	else {
		thruster_speed = 0;
	}
	
        transform.Rotate(new Vector3(0, 0, -1) * rotateSpeed * Input.GetAxis("Roll") * Time.deltaTime);

        transform.Rotate(new Vector3(1, 0, 0) * downAndUpSpeed * Input.GetAxis("UpDown") * Time.deltaTime);

        transform.Rotate(new Vector3(0, 1, 0) * turnSpeed * thruster_speed * Time.deltaTime);

        transform.Translate(new Vector3(0, 0, -1) * speed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
