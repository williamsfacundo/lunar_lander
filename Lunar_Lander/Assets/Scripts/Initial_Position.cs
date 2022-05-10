using UnityEngine;

public class Initial_Position : MonoBehaviour
{
    [SerializeField] private GameObject initial_platform;   

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initial_platform.GetComponent<Renderer>().bounds.center;               
    }
}
