using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosAndRot: MonoBehaviour
{
    private GameObject planet;
    private Vector3 direction;
    private float angle;
    private float planetHeigh;
    private float totalHeigh;
    // Start is called before the first frame update
    void Start()
    {
        planetHeigh = GameObject.FindGameObjectWithTag("Info").GetComponent<GlobalVar>().plantetHeigh;
        totalHeigh = planetHeigh + this.GetComponent<BoxCollider2D>().size.x / 2f;
        planet = GameObject.FindGameObjectWithTag("planet");
        direction = this.transform.position - planet.transform.position;
        direction = direction.normalized;
        angle = direction.y > 0 ? Mathf.Acos((float)direction.x) * 180f / 3.141592f -90f: -(Mathf.Acos((float)direction.x) * 180f / 3.14159265359f) + 360f-90f;
        transform.eulerAngles = new Vector3(0, 0, angle);
        transform.position = new Vector3(direction.x * totalHeigh, direction.y * totalHeigh, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        direction = this.transform.position - planet.transform.position;
        direction = direction.normalized;
        angle = direction.y > 0 ? Mathf.Acos((float)direction.x) * 180f / 3.141592f -90f: -(Mathf.Acos((float)direction.x) * 180f / 3.14159265359f) + 360f-90f;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
