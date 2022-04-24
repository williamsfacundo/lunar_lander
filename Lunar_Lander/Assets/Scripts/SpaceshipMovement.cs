using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField] private Vector2 horizontalSpeed = new Vector3(4f, 0f);
    [SerializeField] private Vector2 verticalSpeed = new Vector3(0f, -4f);
    [SerializeField] private Vector2 fallingVelocity = new Vector3(0f, -1f);

    private Rigidbody2D rigidBody2D;

    private const float moonGravity = 1.625f;   

    private Vector2 twoDimensionsPosition = new Vector2();    

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }    

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveSpaceship();
        SpaceshipFalling();
    }

    private void MoveSpaceship()
    {
        twoDimensionsPosition.x = transform.position.x; 
        twoDimensionsPosition.y = transform.position.y;       
        
        rigidBody2D.MovePosition(twoDimensionsPosition + (horizontalSpeed + verticalSpeed * Time.deltaTime));        
    }

    private void SpaceshipFalling() 
    {
        verticalSpeed += fallingVelocity * moonGravity * Time.deltaTime;
    }
    
    public void RestSpeed(Vector2 value) 
    {
        horizontalSpeed.x -= value.x;
        verticalSpeed.y -= value.y;
    }
}
