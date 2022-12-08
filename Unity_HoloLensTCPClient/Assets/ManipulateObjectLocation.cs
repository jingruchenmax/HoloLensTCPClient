using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateObjectLocation : MonoBehaviour
{
    // boundary vertex numbering: 
    //   0 --- 1
    //   |     |
    //   3 --- 2

    public List<GameObject> vertex;
    Vector3 surfaceNormal;
    public GameObject manipuatedObject;
    // Start is called before the first frame update
    void Start()
    {
        SetToPlaygroundCenter();
    }

    void CalculateNormal()
    {
        if (vertex.Count == 4)
        {
            surfaceNormal = Vector3.Normalize(Vector3.Cross((vertex[0].transform.position - vertex[1].transform.position), (-vertex[2].transform.position + vertex[1].transform.position)));
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetToPlaygroundCenter()
    {
        CalculateNormal();
        manipuatedObject.transform.position = (vertex[0].transform.position+vertex[2].transform.position)/2;
        manipuatedObject.transform.up = surfaceNormal;
    }

    public void SetLocation(Vector2 flatLocation)
    {
        Vector3 i = vertex[1].transform.position - vertex[0].transform.position;
        Vector3 j = vertex[3].transform.position - vertex[0].transform.position;
        manipuatedObject.transform.position = i * flatLocation.x + j * flatLocation.y;
        manipuatedObject.transform.up = surfaceNormal;
    }
}
