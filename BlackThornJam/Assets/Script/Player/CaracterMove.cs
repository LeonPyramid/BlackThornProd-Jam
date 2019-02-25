using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaracterMove : MonoBehaviour
{
    private Rigidbody2D rigidbodyp;
    private GameObject planet;
    private Vector3 direction;
    private float angle;
    private bool contact;
    public Vector3 pdir  { get { return direction; } }
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyp = this.GetComponent<Rigidbody2D>();
        planet = GameObject.FindGameObjectWithTag("planet");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = this.transform.position - planet.transform.position;
        direction = direction.normalized;
        angle = direction.y > 0 ? Mathf.Acos((float)direction.x) * 180f / 3.14159265359f -90f: - (Mathf.Acos((float)direction.x) * 180f / 3.14159265359f) + 360f-90f;
        transform.eulerAngles = new Vector3(0, 0, angle);
        if (Input.GetKey(KeyCode.LeftArrow)&&contact)
        {
            rigidbodyp.AddForce(new Vector2(10000f*(direction.x-direction.y*0.5f),10000f*(direction.y+direction.x*0.5f)));
            contact = false;
        }
        if (Input.GetKey(KeyCode.RightArrow) && contact)
        {
            rigidbodyp.AddForce(new Vector2(10000f * (direction.x + direction.y*0.5f), 10000f * (direction.y - direction.x*0.5f)));
            contact = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "planet")
        {
            contact = true;
        }
    }
}
