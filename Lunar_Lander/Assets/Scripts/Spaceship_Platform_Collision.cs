using UnityEngine;

public class Spaceship_Platform_Collision : MonoBehaviour
{
    [SerializeField] private SpaceshipMovement spaceshipMovement;

    [SerializeField] private Score score;

    [SerializeField] private float angleToResetPosition;

    [SerializeField] private float maxCollisionVelocity;

    private const int pointsPerLanding = 5;

    //private bool isCollidingWithPlatform;

    //private float timerToAddPoint;
    //private const float timeToAddPoint = 1f;

    /*void Start() 
    {
        timerToAddPoint = timeToAddPoint;
    }

    void Update()
    {
        if (isCollidingWithPlatform) 
        {
            timerToAddPoint -= Time.deltaTime;
        }

        if (timerToAddPoint == 0f) 
        {
            score.ScoreUp(pointsPerLanding);
            spaceshipMovement.RestartGameObject();
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        InitialPlatformCollison(collision);

        NormalPlatformCollision(collision);
    }
    

    private void InitialPlatformCollison(Collision collision) 
    {
        if (collision.transform.CompareTag("Initial_Platform"))
        {
            SpaceshipFall();
        }
    }
    
    private void NormalPlatformCollision(Collision collision) 
    {
        if (collision.transform.CompareTag("Platform"))
        {
            if (collision.relativeVelocity.y < maxCollisionVelocity && Vector3.Angle(transform.up, Vector3.up) <= 5f)
            {
                score.ScoreUp(pointsPerLanding);
                spaceshipMovement.RestartGameObject();                
            }
            else
            {
                spaceshipMovement.RestartGameObject();
            }
        }
    }

    private void SpaceshipFall() 
    {
        if (Vector3.Angle(transform.up, Vector3.up) >= angleToResetPosition) //80f
        {
            spaceshipMovement.RestartGameObject();
        }
    }
}
