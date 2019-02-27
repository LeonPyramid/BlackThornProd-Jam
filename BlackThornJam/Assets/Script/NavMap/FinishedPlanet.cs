using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FinishedPlanet : MonoBehaviour
{
    public PlanetInfo info;
    public GameObject flag;
    // Start is called before the first frame update
    void Start()
    {
        info = LoadPlanet();
        if(info.win&&File.Exists(Path.Combine(Application.persistentDataPath, "Test.txt")))
        {
            flag.SetActive(true);
        }
        else
        {
            flag.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public PlanetInfo LoadPlanet()
    {
         string planetName = this.name + ".txt";
        string dataPath = Path.Combine(Application.persistentDataPath, planetName);
        Debug.Log(dataPath);
        using (StreamReader streamReader = File.OpenText(dataPath))
        {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<PlanetInfo>(jsonString);
        }

    }
}
