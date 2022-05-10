using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField] private float speed; 
    [SerializeField] private float yGravity = -1.6f;

    private Rigidbody rb;      
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();        
    }

    private void Start()
    {
        Physics.gravity = new Vector3(0f, yGravity, 0f);
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
            rb.AddForce(transform.up * speed * Time.deltaTime, ForceMode.Acceleration);
        }        
    }

    private void ChangeRigidBodyIfIsKinematic() 
    {
        if (rb.isKinematic) 
        {
            rb.isKinematic = false;
        }
    }

    public void SetRigidIsKinematic(bool isKinematic) 
    {
        rb.isKinematic = isKinematic;
    }
}
