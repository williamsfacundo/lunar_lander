    using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]


public class SpaceshipRotation : MonoBehaviour
{
    [SerializeField] private float spaceshipRotationValue = 5f;

    private Rigidbody rb;

    Vector3 rotation;
        
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }  

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateSpaceship();
    }

    void RotateSpaceship() 
    {
        rotation.x = Input.GetAxisRaw("Vertical") * Time.deltaTime * spaceshipRotationValue;
        rotation.z = Input.GetAxisRaw("Horizontal") * Time.deltaTime * spaceshipRotationValue;

        rb.AddTorque(rotation);

        if (Vector3.Angle(transform.up, Vector3.up) > 90f) 
        {
            rb.angularVelocity = Vector3.zero;
        }        
    }   
}
