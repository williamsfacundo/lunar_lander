using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Following_Player : MonoBehaviour
{
    [SerializeField] private GameObject spaceship;
    [SerializeField] private Vector3 camera_offset;
    

    // Start is called before the first frame update
    void Start()
    {
        CameraUpdatePosition();               
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CameraUpdatePosition();
    }

    private void CameraUpdatePosition() 
    {
        transform.position = spaceship.transform.position - camera_offset;
    }
}
