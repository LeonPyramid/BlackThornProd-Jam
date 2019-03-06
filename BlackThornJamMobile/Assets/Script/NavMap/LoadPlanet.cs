using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
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
    public GameObject loadScreen;
    public MoveScript[] UIbutton;
    // Start is called before the first frame update
    void Start()
    {
        UIbutton = FindObjectsOfType<MoveScript>();
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
        bool test = false;
        foreach(MoveScript move in UIbutton)
        {
            if (move.UIblock)
            {
                test = true;
                Debug.Log("BLockUI");
            }
        }
        if (zone <= open.openArea && !test&& !IsPointerOverUIObject())

        {
            loadScreen.SetActive(true);
            FindObjectOfType<MoveCamera>().SavePos();
            SceneManager.LoadScene(planetName);
        }

        
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

}
