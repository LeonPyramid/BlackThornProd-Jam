using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveFromWorld : MonoBehaviour
{

    string dataPath;
    string toolPath;
    string planetName;

    void Start()
    {
        toolPath = Path.Combine(Application.persistentDataPath,"Tool.txt");
        planetName = SceneManager.GetActiveScene().name + ".txt";
        dataPath = Path.Combine(Application.persistentDataPath, planetName);
            
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(GameObject.FindGameObjectWithTag("Info").GetComponent<GlobalVar>().PlanetInfo);

        using (StreamWriter streamWriter = File.CreateText(dataPath))
        {
            Debug.Log("coucou");
            streamWriter.Write(jsonString);
        }
        string jsontool = JsonUtility.ToJson(GameObject.FindGameObjectWithTag("Info").GetComponent<GlobalVar>().dispoTool);

        using (StreamWriter streamWriter = File.CreateText(toolPath))
        {
            Debug.Log("coucou");
            streamWriter.Write(jsontool);
        }
    }
    public PlanetInfo LoadPlanet()
    {
        planetName = SceneManager.GetActiveScene().name + ".txt";
        dataPath = Path.Combine(Application.persistentDataPath, planetName);
        Debug.Log(dataPath);
        using (StreamReader streamReader = File.OpenText(dataPath))
        {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<PlanetInfo>(jsonString);
        }

    }
    public DisponibleTool LoadTool()
    {
        toolPath = Path.Combine(Application.persistentDataPath, "Tool.txt");
        using (StreamReader streamReader = File.OpenText(toolPath))
        {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<DisponibleTool>(jsonString);
        }
    }


}
