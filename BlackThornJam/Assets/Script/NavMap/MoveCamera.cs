using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MoveCamera : MonoBehaviour
{
    public float force;
    public CameraRemember cam;
    void Start()
    {
        if(File.Exists(Path.Combine(Application.persistentDataPath, "Cam.txt")))
        {
            transform.position = new Vector3(camLoad().xPos, transform.position.y, transform.position.z);
        }
    }

    void Update()
    {
        if (transform.position.x > -11&&(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))
        {
            transform.position = new Vector3(transform.position.x - force, transform.position.y,transform.position.z);
        }
        if (transform.position.x < -11)
        {
            transform.position = new Vector3(-11, transform.position.y,transform.position.z);
        }
        if (transform.position.x < 431 && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
        {
            transform.position = new Vector3(transform.position.x + force, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 431)
        {
            transform.position = new Vector3(431, transform.position.y, transform.position.z);
        }
        cam.xPos = transform.position.x;
    }
    public void SavePos()
    {
        string jsonString = JsonUtility.ToJson(cam);

        using (StreamWriter streamWriter = File.CreateText(Path.Combine(Application.persistentDataPath,"Cam.txt")))
        {
            streamWriter.Write(jsonString);
        }
    }
    public CameraRemember camLoad()
    {
        using (StreamReader streamReader = File.OpenText(Path.Combine(Application.persistentDataPath, "Cam.txt")))
        {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<CameraRemember>(jsonString);
        }
    }
}
