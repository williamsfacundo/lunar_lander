using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public class SpaceshipRotation : MonoBehaviour
{
    [SerializeField] private float spaceshipRotationValue = 90f;

    private Rigidbody rigidBody;   

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }  

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateSpaceship();        
    }

    void RotateSpaceship() 
    {
        float xRotation = Input.GetAxisRaw("Vertical") * Time.deltaTime * spaceshipRotationValue;
        float zRotation = Input.GetAxisRaw("Horizontal") * Time.deltaTime * spaceshipRotationValue;
        
        rigidBody.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles.x + xRotation, 0f, transform.rotation.eulerAngles.z + zRotation));        
    }
}
