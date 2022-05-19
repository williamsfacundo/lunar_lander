using UnityEngine;

public class Spaceship_Platform_Collision : MonoBehaviour
{
    [SerializeField] private SpaceshipMovement spaceshipMovement;

    [SerializeField] private Score score;

    [SerializeField] private float angleToResetPosition;

    [SerializeField] private float maxCollisionVelocity;

    [SerializeField] private float timeToAddPoint = 2.0f;

    private const int pointsPerLandingMultiplayer = 5;    

    private float timerToAddPoint = 0f;       

    private void OnCollisionEnter(Collision collision)
    {
        NormalPlatformCollision(collision);
    }

    private void NormalPlatformCollision(Collision collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {
            if (CorrectVelocity(collision))
            {
                timerToAddPoint = timeToAddPoint;
            }
            else
            {
                spaceshipMovement.RestartGameObject();
            }
        }
    }

    private bool CorrectVelocity(Collision collision) 
    {
        bool correctVelocity = true;

        if (collision.relativeVelocity.y > 0f) 
        {
            correctVelocity = collision.relativeVelocity.y < maxCollisionVelocity;
        }
        else 
        {
            return collision.relativeVelocity.y > -maxCollisionVelocity;
        }

        if (correctVelocity) 
        {
            if (collision.relativeVelocity.x > 0f)
            {
                correctVelocity = collision.relativeVelocity.x < maxCollisionVelocity;
            }
            else
            {
                return collision.relativeVelocity.x > -maxCollisionVelocity;
            }
        }        

        return correctVelocity;
    }
    
    private void SpaceshipFall() 
    {
        if (Vector3.Angle(transform.up, Vector3.up) >= angleToResetPosition) //80f
        {
            spaceshipMovement.RestartGameObject();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        SpaceshipFall();

        if (collision.transform.CompareTag("Platform")) 
        {
            if (Vector3.Angle(transform.up, Vector3.up) <= 5f) 
            {
                timerToAddPoint -= Time.deltaTime;

                if (timerToAddPoint <= 0f)
                {
                    spaceshipMovement.RestartGameObject();
                    score.ScoreUp(CalculateScoreDependingDistance(collision));
                }
            }
            else 
            {
                if (timerToAddPoint != timeToAddPoint) 
                {
                    timerToAddPoint = timeToAddPoint;
                }
            }            
        }
    }

    int CalculateScoreDependingDistance(Collision collision) 
    {
        return (int)(Vector3.Distance(collision.transform.position, transform.position) * pointsPerLandingMultiplayer);
    }
}
