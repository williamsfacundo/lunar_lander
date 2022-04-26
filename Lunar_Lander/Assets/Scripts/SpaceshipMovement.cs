using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField] private Vector3 speed;

    [SerializeField] private Vector3 velocity; 
    
    private Rigidbody rb;      
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveSpaceship();       
    }

    private void MoveSpaceship()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            rb.AddForce(transform.up, ForceMode.Impulse);
        }                  
    }   
}
