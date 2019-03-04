using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private Vector3 direction;
    private float planetHeigh;
    private float camHeigh;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        planetHeigh = GameObject.FindGameObjectWithTag("Info").GetComponent<GlobalVar>().plantetHeigh;
        camHeigh = planetHeigh + player.GetComponent<BoxCollider2D>().size.x / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.GetComponent<CaracterMove>().pdir;
        transform.position = new Vector3(direction.x * camHeigh, direction.y * camHeigh, transform.position.z);
        
    }
}
