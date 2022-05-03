using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField] private float speed; 
    [SerializeField] private float gravity = 16f;

    private Rigidbody rb;

    private bool colliding;    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();        
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        ChangeRigidBodyIfIsKinematic();

        MoveSpaceship();        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!colliding)
        { 
            colliding = true; 
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (colliding)
        {
            colliding = false;
        }
    }

    private void MoveSpaceship()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            rb.AddForce(transform.up * speed * Time.deltaTime, ForceMode.Impulse);
        }
        else if(!colliding) 
        {
            rb.AddForce(-transform.up * gravity * Time.deltaTime);
        }
    }

    private void ChangeRigidBodyIfIsKinematic() 
    {
        if(rb.isKinematic) 
        {
            rb.isKinematic = false;
        }
    }

    public void SetRigidIsKinematic(bool isKinematic) 
    {
        rb.isKinematic = isKinematic;
    }
}
