using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpLeft : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private GameObject planet;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        planet = GameObject.FindGameObjectWithTag("planet");
    }

    // Update is called once per frame
    void Update()
    {
        direction = this.transform.position - planet.transform.position;
        direction = direction.normalized;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(new Vector2(10000f*(direction.x-direction.y),10000f*(direction.y+direction.x)));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rigidbody.AddForce(new Vector2(10000f * (direction.x + direction.y), 10000f * (direction.y - direction.x)));
        }
    }
}
