using UnityEngine;

public class Initial_Position : MonoBehaviour
{
    [SerializeField] private GameObject initial_platform;

    [SerializeField] private float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initial_platform.GetComponent<Renderer>().bounds.center + (Vector3.up * yOffset);               
    }
}
