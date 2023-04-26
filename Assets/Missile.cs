using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private GameObject _missile;
    [SerializeField] private int speed = 100;
    [SerializeField] float cooldown = 1f;
    private float cooldownTimestamp;

    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if pressed spacebar, fire rocket
        if(Input.GetKey("space"))
        {
            try_fire();
        }
    }

    void try_fire()
    {
        if (Time.time < cooldownTimestamp) return;
        cooldownTimestamp = Time.time + cooldown;
        // fire from right launcher
        Vector3 missile_spawn = transform.position + transform.right * 5 + transform.up * 3;
        var missile = Instantiate(_missile, missile_spawn, transform.rotation);
        var missile_rb = missile.GetComponent<Rigidbody>();
        missile_rb.AddForce(transform.TransformDirection(Vector3.forward) * speed + GetComponent<Rigidbody>().velocity, ForceMode.VelocityChange);
        // fire from left launcher
        Vector3 missile_spawn_left = transform.position + transform.right * -5 + transform.up * 3;
        var missile_left = Instantiate(_missile, missile_spawn_left, transform.rotation);
        var missile_rb_left = missile_left.GetComponent<Rigidbody>();
        missile_rb_left.AddForce(transform.TransformDirection(Vector3.forward) * speed + GetComponent<Rigidbody>().velocity, ForceMode.VelocityChange);
    }
}
