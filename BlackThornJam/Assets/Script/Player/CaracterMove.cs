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
    private float scale;
    public Vector3 pdir  { get { return direction; } }
    private bool contactVerif;
    private float timer;
    public float jumpTime;
    public AudioSource m_JumpStream;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale.y;
        rigidbodyp = this.GetComponent<Rigidbody2D>();
        planet = GameObject.FindGameObjectWithTag("planet");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        contactVerif = contact;
        direction = this.transform.position - planet.transform.position;
        direction = direction.normalized;
        angle = direction.y > 0 ? Mathf.Acos((float)direction.x) * 180f / 3.14159265359f -90f: - (Mathf.Acos((float)direction.x) * 180f / 3.14159265359f) + 360f-90f;
        transform.eulerAngles = new Vector3(0, 0, angle);
        if (Input.GetKey(KeyCode.LeftArrow)&&contact)
        {
            rigidbodyp.AddForce(new Vector2(10000f*(direction.x-direction.y*0.5f),10000f*(direction.y+direction.x*0.5f)));
            m_JumpStream.Play();
            contact = false;
        }
        if (Input.GetKey(KeyCode.RightArrow) && contact)
        {
            rigidbodyp.AddForce(new Vector2(10000f * (direction.x + direction.y*0.5f), 10000f * (direction.y - direction.x*0.5f)));
            m_JumpStream.Play();
            contact = false;
        }
        if (!contact&&contact!=contactVerif)
        {
            timer = jumpTime;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x, scale + 0.2f, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, scale , transform.localScale.z);
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
