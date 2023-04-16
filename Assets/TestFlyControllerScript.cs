using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, -1) * rotateSpeed * Input.GetAxis("Roll") * Time.deltaTime);

        transform.Rotate(new Vector3(1, 0, 0) * downAndUpSpeed * Input.GetAxis("UpDown") * Time.deltaTime);

        transform.Rotate(new Vector3(0, 1, 0) * turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);

        transform.Translate(new Vector3(0, 0, -1) * speed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
