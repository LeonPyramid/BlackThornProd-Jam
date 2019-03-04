using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EasterEggPlanet : MonoBehaviour
{
    public PlanetInfo info;
    public Sprite planet;
    public GameObject Planet23;
    // Start is called before the first frame update
    void Start()
    {
        Planet23 = GameObject.Find("Planet23");
        info = LoadPlanet();
        if (info.win && File.Exists(Path.Combine(Application.persistentDataPath, "Test.txt")))
        {
        }
        else
        {
            Planet23.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public PlanetInfo LoadPlanet()
    {
        string planetName ="Planet23.txt";
        string dataPath = Path.Combine(Application.persistentDataPath, planetName);
        Debug.Log(dataPath);
        using (StreamReader streamReader = File.OpenText(dataPath))
        {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<PlanetInfo>(jsonString);
        }

    }
}
