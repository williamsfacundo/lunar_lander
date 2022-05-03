using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_Platform_Collision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Platform") && collision.relativeVelocity.y >= transform.up.y) 
        {

        }        
    }
}
