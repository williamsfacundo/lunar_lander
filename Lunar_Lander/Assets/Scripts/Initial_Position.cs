using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initial_Position : MonoBehaviour
{
    [SerializeField] private GameObject terrain_gameObject;

    Terrain terrain_data;

    private void Awake()
    {
        terrain_data = terrain_gameObject.GetComponent<Terrain>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 newPosition = terrain_gameObject.transform.position + terrain_data.terrainData.size / 2;
        float yPos = transform.position.y;

        newPosition.y = yPos; 

        transform.position = newPosition;         
    }
}
