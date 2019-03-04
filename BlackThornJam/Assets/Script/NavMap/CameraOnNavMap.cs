using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnNavMap : MonoBehaviour
{
    public GameObject area;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, area.transform.position.y, transform.position.z);
    }
}
