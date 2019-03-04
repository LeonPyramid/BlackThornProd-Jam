using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFlyer : MonoBehaviour
{
    private GameObject planet;
    private Vector3 direction;
    private float angle;
    private float planetHeigh;
    private float totalHeigh;
    public float cloudHeigh;
    public float speed;
    private float angleSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if (cloudHeigh == 0)
        {
            cloudHeigh = this.GetComponent<BoxCollider2D>().size.x / 2f;
        }
        planetHeigh = GameObject.FindGameObjectWithTag("Info").GetComponent<GlobalVar>().plantetHeigh;
        totalHeigh = planetHeigh + cloudHeigh;
        planet = GameObject.FindGameObjectWithTag("planet");
        direction = this.transform.position - planet.transform.position;
        direction = direction.normalized;
        angle = direction.y > 0 ? Mathf.Acos((float)direction.x) * 180f / 3.141592f - 90f : -(Mathf.Acos((float)direction.x) * 180f / 3.14159265359f) + 360f - 90f;
        transform.eulerAngles = new Vector3(0, 0, angle);
        transform.position = new Vector3(direction.x * totalHeigh, direction.y * totalHeigh, transform.position.z);
        angleSpeed = direction.y > 0 ? Mathf.Acos((float)direction.x): -(Mathf.Acos((float)direction.x)) + 2f*3.141592f;
    }
    // Update is called once per frame
    void Update()
    {
        angleSpeed += speed;
        direction = new Vector3(Mathf.Cos(angleSpeed), Mathf.Sin(angleSpeed));
        angle = direction.y > 0 ? Mathf.Acos((float)direction.x) * 180f / 3.141592f - 90f : -(Mathf.Acos((float)direction.x) * 180f / 3.14159265359f ) + 360f - 90f ;
        transform.position = new Vector3(direction.x* totalHeigh,direction.y * totalHeigh, transform.position.z);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
