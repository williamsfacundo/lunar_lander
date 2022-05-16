using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_Platform_Collision : MonoBehaviour
{
    [SerializeField] private SpaceshipMovement spaceshipMovement;

    [SerializeField] private float angleToResetPosition;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Platform")) 
        {
            if (Vector3.Angle(transform.up, Vector3.up) >= angleToResetPosition) //80f
            {               
                spaceshipMovement.RestartGameObject();
            }
        }        
    }
}
