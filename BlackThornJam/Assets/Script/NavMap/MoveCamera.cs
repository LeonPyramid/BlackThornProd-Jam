using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float force;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x > -11&&Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - force, transform.position.y,transform.position.z);
        }
        if (transform.position.x < -11)
        {
            transform.position = new Vector3(-11, transform.position.y,transform.position.z);
        }
        if (transform.position.x < 431 && Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + force, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 431)
        {
            transform.position = new Vector3(431, transform.position.y, transform.position.z);
        }
    }
}
