using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart_Position_On_Collision : MonoBehaviour
{
    [SerializeField] private SpaceshipMovement spaceshipMovement;

    private Vector3 initialPosition;
    private Vector3 initialRotation;    

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation.eulerAngles;        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Vector3.Angle(transform.up, Vector3.up) > 90f)
        {
            transform.position = initialPosition;
            transform.eulerAngles = initialRotation;
            spaceshipMovement.SetRigidIsKinematic(true);            
        }       
    }
}
