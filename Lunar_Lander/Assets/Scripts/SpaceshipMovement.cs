using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 80;
    [SerializeField] private float verticalSpeed = 5;

    private Rigidbody2D rigidBody2D;

    private const float moonGravity = 1.625f;

    private Vector2 twoDimensionsPosition;
    private Vector2 twoDimensionsMoveValue;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }    

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveSpaceship();                        
    }

    private void MoveSpaceship()
    {
        twoDimensionsPosition = new Vector2(transform.position.x, transform.position.y);        
        twoDimensionsMoveValue = new Vector2(horizontalSpeed * Time.deltaTime, -verticalSpeed * Time.deltaTime * moonGravity);
        
        rigidBody2D.MovePosition(twoDimensionsPosition + twoDimensionsMoveValue);
    }    
}
