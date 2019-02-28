using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class CreateSavefile : MonoBehaviour
{
    public GameObject[] planets;
    private string pathToTest;
    public string dataPath;
    private int count;
    private string planetName;
    public DisponibleTool disponible;
    public PlanetInfo planetInfo;
    public string toolPath;
    public ZoneStade zone;
    public bool overrideSave;
    public TutoStat tutoStat;
    // Start is called before the first frame update
    void Start()
    {

        planets = GameObject.FindGameObjectsWithTag("planet");
        pathToTest = Path.Combine(Application.persistentDataPath, "Test.txt");
        toolPath = Path.Combine(Application.persistentDataPath, "Tool.txt");
        if (overrideSave) { File.Delete(pathToTest); }
        if (!File.Exists(pathToTest))
        {
            tutoStat.stat = 0;
            File.Create(pathToTest);
            zone.openArea = 0;
            SaveZone();
            Debug.Log("tamer");
            count = 0;
            disponible.dispoTools = new bool[10] { true, true, true, true, false, false, false, false, false, false };
            foreach (GameObject planet in planets)
            {
                planetName = planet.name + ".txt";
                dataPath = Path.Combine(Application.persistentDataPath, planetName);
                Save(dataPath);
                Debug.Log(dataPath);
            }
            tool();
            SaveTuto();
            SceneManager.LoadScene("Planet0");
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
    public void tool()
    {
        string tooljson = JsonUtility.ToJson(disponible);
        using (StreamWriter streamWriter = File.CreateText(toolPath))
        {
            streamWriter.Write(tooljson);
        }
    }
    public void SaveZone()
    {
        string json = JsonUtility.ToJson(zone);
        using (StreamWriter str = File.CreateText(Path.Combine(Application.persistentDataPath, "Zone.txt")))
        {
            str.Write(json);
        }
    }
    public void SaveTuto()
    {
        string json = JsonUtility.ToJson(tutoStat);
        using (StreamWriter str = File.CreateText(Path.Combine(Application.persistentDataPath, "Tuto.txt")))
        {
            str.Write(json);
        }
    }


}
