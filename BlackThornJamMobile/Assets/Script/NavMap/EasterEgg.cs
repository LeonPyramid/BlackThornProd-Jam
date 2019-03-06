using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class EasterEgg : MonoBehaviour
{
    public bool lock1;
    public bool lock2;
    public bool lock3;
    private float tempx;
    public PlanetInfo planetInfo;

    public bool easter;
    void Start()
    {
        if (!File.Exists(Path.Combine(Application.persistentDataPath, "Planet24.txt")))
        {
            Save(Path.Combine(Application.persistentDataPath, "Planet24.txt"));
        }
        lock1 = false;
        lock2 = false;
        lock3 = false;
        easter = false;
    }

    void Update()
    {
        if(this.transform.position.x ==-11 && !lock1)
        {
            lock1 = true;
            tempx = -11;
        }
        if(this.transform.position.x>=tempx && lock1 && !lock2)
        {
            tempx = transform.position.x;
        }
        else if (transform.position.x < tempx && lock1 && !lock2)
        {
            lock1 = false;
        }
        if (this.transform.position.x == 431 && lock1 &&!lock2)
        {
            lock2 = true;
            tempx = 431;
        }
        if (this.transform.position.x <= tempx && lock2 && !lock3)
        {
            tempx = transform.position.x;
        }
        else if (this.transform.position.x > tempx && lock2 && !lock3)
        {
            lock1 = false;
            lock2 = false;
        }
        if (this.transform.position.x == -11 && lock2 && !lock3)
        {
            lock3 = true;
            tempx = -11;
        }
        if (this.transform.position.x >= tempx && lock3)
        {
            tempx = transform.position.x;
        }
        else if (this.transform.position.x < tempx && lock3)
        {
            lock1 = false;
            lock2 = false;
            lock3 = false;
        }
        if (this.transform.position.x == 431 && lock3)
        {
            easter = true;
            SceneManager.LoadScene("Planet24");
        }
    }
    public void Save(string dataPath)
    {
        string jsonString = JsonUtility.ToJson(planetInfo);

        using (StreamWriter streamWriter = File.CreateText(dataPath))
        {
            streamWriter.Write(jsonString);
        }

    }
}
