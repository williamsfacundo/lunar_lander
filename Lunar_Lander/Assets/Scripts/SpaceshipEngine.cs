using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipEngine : MonoBehaviour
{
    [SerializeField] private KeyCode useEngineKey;

    [SerializeField] private SpaceshipMovement spaceshipMovement;

    [SerializeField] private Vector2 engineForce = new Vector2(0.05f, 0.05f);

    private void Update()
    {
        UseEngine();
    }

    void UseEngine() 
    {
        if (Input.GetKey(useEngineKey)) 
        {
            spaceshipMovement.RestSpeed(engineForce * Time.deltaTime);
        }
    }
}
