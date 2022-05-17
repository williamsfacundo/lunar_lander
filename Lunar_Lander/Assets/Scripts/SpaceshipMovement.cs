using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField] private Text fuelText;
    [SerializeField] private float speed; 
    [SerializeField] private float yGravity = -1.6f;
    [SerializeField] private float initialFuel = 40f;

    private Rigidbody rb;

    private Vector3 initialPosition;
    private Vector3 initialRotation;

    private float fuel;

    private const float fuelConsumptionRate = 1f;
    private const float yLimit = -10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();        
    }

    private void Start()
    {
        Physics.gravity = new Vector3(0f, yGravity, 0f);

        initialPosition = gameObject.transform.position;
        initialRotation = gameObject.transform.eulerAngles;

        fuel = initialFuel;
    }

    private void Update()
    {
        fuelText.text = "Fuel " + (short)fuel;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ChangeRigidBodyIfIsKinematic();

        MoveSpaceship();

        ChangeSceneIfThereIsNoMoreFuel();

        PlayerYPositionPassLimit();
    } 
    
    private void ChangeSceneIfThereIsNoMoreFuel() 
    {
        if (fuel <= 0f) 
        {
            SceneManager.LoadScene("EndGame");                                    
        }
    }

    private void PlayerYPositionPassLimit() 
    {
        if (transform.position.y <= yLimit) 
        {
            RestartGameObject();
        }
    }

    private void MoveSpaceship()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            rb.AddForce(transform.up * speed * Time.deltaTime, ForceMode.Acceleration);

            RestFuel();
        }        
    }

    private void RestFuel() 
    {
        fuel -= fuelConsumptionRate * Time.deltaTime;

        if (fuel < 0)
        {
            fuel = 0f;
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

    public void RestartGameObject() 
    {
        rb.isKinematic = true;
        rb.isKinematic = false;

        gameObject.transform.position = initialPosition;
        gameObject.transform.eulerAngles = initialRotation;
    }
}
