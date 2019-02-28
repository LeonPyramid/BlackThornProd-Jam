using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadPlanet : MonoBehaviour
{
    public int planetNum;
    private string planetName;
    public string name;
    public int zone;
    public Color hidden;
    public Color basic;
    public ZoneStade open;
    // Start is called before the first frame update
    void Start()
    {
        open = LoadZone();
        basic = GetComponent<SpriteRenderer>().color;
        planetName = "Planet" + planetNum.ToString();
        if (name != "")
        {
            planetName = "Planet" + name;
        }
        if ( zone > open.openArea)
        {
            foreach(SpriteRenderer sprt in GetComponentsInChildren<SpriteRenderer>())
            {
                sprt.color = hidden;
                Debug.Log("ff");
            }
        }
        else
        {
            foreach(SpriteRenderer sprt in GetComponentsInChildren<SpriteRenderer>())
            {
                Debug.Log("gg");
            }
        }

    }
    public ZoneStade LoadZone()
    {
        using (StreamReader streamReader = File.OpenText(Path.Combine(Application.persistentDataPath, "Zone.txt")))
        {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<ZoneStade>(jsonString);
        }
    }
    private void OnMouseDown()
    {
        if (zone <= open.openArea)
        {
            SceneManager.LoadScene(planetName);
        }
        
    }
}
