using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
    public bool overrideSave;
    // Start is called before the first frame update
    void Start()
    {
        planets = GameObject.FindGameObjectsWithTag("planet");
        pathToTest = Path.Combine(Application.persistentDataPath, "Test.txt");
        toolPath = Path.Combine(Application.persistentDataPath, "Tool.txt");
        //sr = File.OpenRead(pathToTest);
        if (overrideSave) { File.Delete(pathToTest); }
        if (!File.Exists(pathToTest)/*||sr.ToString() == ""*/)
        {
            File.Create(pathToTest);
            //sr.Write(new byte[] { 20 }, 0, 1);
            Debug.Log("tamer");
            count = 0;
            disponible.dispoTools = new bool[10] { true, true, true, true, false, false, false, false, false, false };
            foreach (GameObject planet in planets)
            {
                planetName = "Planet" + count.ToString() + ".txt";
                dataPath = Path.Combine(Application.persistentDataPath, planetName);
                Save(dataPath);
                Debug.Log(dataPath);
            }
            tool();

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


}
