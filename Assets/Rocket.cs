using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    [SerializeField] private int missile_speed = 100;

    public Rigidbody rocket_rb;
    // Start is called before the first frame update
    void Start()
    {
        rocket_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // give the rocket thrust so ship does not catch up
        rocket_rb.AddForce(transform.TransformDirection(Vector3.forward) * missile_speed, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
