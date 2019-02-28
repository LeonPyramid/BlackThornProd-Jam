using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Forcer : MonoBehaviour
{
    public int zonei;
    private bool win;
    private bool first;
    public ZoneStade zone;
    // Start is called before the first frame update
    void Start()
    {
        first = true;
    }

    // Update is called once per frame
    void Update()
    {
        win = FindObjectOfType<GlobalVar>().win;
        if(first && win)
        {
            Debug.Log("ok");
            first = false;
            zone.openArea = zonei;
            SaveZone(zone);
        }
    }
    public void SaveZone(ZoneStade zoneWin)
    {
        string json = JsonUtility.ToJson(zoneWin);
        using (StreamWriter str = File.CreateText(Path.Combine(Application.persistentDataPath, "Zone.txt")))
        {
            str.Write(json);
        }
    }
}
