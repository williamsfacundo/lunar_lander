using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class SpaceshipRotation : MonoBehaviour
{
    [SerializeField] private KeyCode rotateRightKey = KeyCode.RightArrow;
    [SerializeField] private KeyCode rotateLeftKey = KeyCode.LeftArrow;

    private Rigidbody2D rigidBody2D;

    private float spaceshipRotationValue = 90f;    
    

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }  

    // Update is called once per frame
    void FixedUpdate()
    {
        float valueOne = transform.eulerAngles.z + (spaceshipRotationValue * Time.deltaTime);
        float valueTwo = transform.eulerAngles.z - (spaceshipRotationValue * Time.deltaTime);

        if ((valueOne > -5 && valueOne < 90) || (valueOne > 270 && valueOne < 365))
        {
            RotateSpaceshipWhenKeyPressed(spaceshipRotationValue, rotateRightKey);
        }        

        if ((valueTwo > -5 && valueTwo < 90) || (valueTwo > 270 && valueTwo < 365))
        {
            RotateSpaceshipWhenKeyPressed(-spaceshipRotationValue, rotateLeftKey);
        }       
    }

    void RotateSpaceship(float value) 
    {
        rigidBody2D.MoveRotation(transform.eulerAngles.z + (value * Time.deltaTime));        
    }

    void RotateSpaceshipWhenKeyPressed(float value, KeyCode key) 
    {
        if (Input.GetKey(key)) 
        {
            RotateSpaceship(value);
        }
    }
}
