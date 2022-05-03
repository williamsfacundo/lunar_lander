using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField] private float speed;    
    
    private Rigidbody rb;      
    
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

    private void MoveSpaceship()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            rb.AddForce(transform.up * speed * Time.deltaTime, ForceMode.Impulse);
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
