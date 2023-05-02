using UnityEngine;
public class Breakable : MonoBehaviour
{
    [SerializeField] private float _breakForce = 150;

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.relativeVelocity.magnitude > _breakForce)
        //{
           GetComponent<Fracture>().FractureObject(transform.localScale);
        //}
    }
}