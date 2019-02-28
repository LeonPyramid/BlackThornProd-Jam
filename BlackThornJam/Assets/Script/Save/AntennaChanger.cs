using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AntennaChanger : MonoBehaviour
{
    public Sprite[] sprites;

    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = sprites[LoadZone().openArea];
    }

    public ZoneStade LoadZone()
    {
        using (StreamReader streamReader = File.OpenText(Path.Combine(Application.persistentDataPath, "Zone.txt")))
        {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<ZoneStade>(jsonString);
        }
    }
}
