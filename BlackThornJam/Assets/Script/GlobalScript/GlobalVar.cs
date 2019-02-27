using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GlobalVar : MonoBehaviour
{

    public float plantetHeigh;
    public int socialBasic;
    public int ecologieBasic;
    public int argentBasic;
    private int social;
    private int ecologie;
    private int argent;
    public int socialg { get { return social; } }
    public int ecologieg { get { return ecologie; } }
    public int argentg { get { return argent; } }
    private GameObject[] buildable;
    private GameObject choiceMenu;
    private int[] buildId;
    public DisponibleTool dispoTool;
    private GameObject[] choiceMenuBoutton;
    private int count = 1;
    public bool win;
    public int id;
    public PlanetInfo PlanetInfo;
    void Start()
    {
        PlanetInfo = GetComponent<SaveFromWorld>().LoadPlanet();
        dispoTool = GetComponent<SaveFromWorld>().LoadTool();
        buildId = PlanetInfo.buildId;
        buildable = GameObject.FindGameObjectsWithTag("Buildable");
        choiceMenu = FindObjectOfType<MenuForPiple>().menu;
        choiceMenuBoutton = GameObject.FindGameObjectsWithTag("Boutton");
        foreach(GameObject boutton in choiceMenuBoutton)
        {
            GameObject.Find("Button (" + count.ToString() + ")").SetActive(dispoTool.dispoTools[count]);
            count += 1;
        }
        if (PlanetInfo.win)
        {
            GameObject.Destroy(GameObject.FindGameObjectWithTag("Win").gameObject);
        }
        win = PlanetInfo.win;
        count = 0;
        foreach(GameObject build in buildable)
        {
            id = buildId[count];
            build.GetComponent<BuildInfo>().id = id;
            build.GetComponent<BuildInfo>().social = FindObjectOfType<ObjetList>().socialList[id];
            build.GetComponent<BuildInfo>().argent = FindObjectOfType<ObjetList>().argentList[id];
            build.GetComponent<BuildInfo>().ecologie = FindObjectOfType<ObjetList>().ecologieList[id];
            build.GetComponent<SpriteRenderer>().sprite = FindObjectOfType<ObjetList>().imageList[id];
            count += 1;
        }
        choiceMenu.SetActive(false);
    }
    void Update()
    {
        social = socialBasic;
        argent = argentBasic;
        ecologie = ecologieBasic;
        count = 0;
        foreach(GameObject build in buildable)
        {
            PlanetInfo.buildId[count] = build.GetComponent<BuildInfo>().id;
            social += build.GetComponent<BuildInfo>().social;
            argent += build.GetComponent<BuildInfo>().argent;
            ecologie += build.GetComponent<BuildInfo>().ecologie;
            count += 1;
        }
        if (social > 2 && argent > 2 && ecologie > 2)
        {
            win = true;

        }
        PlanetInfo.win = win;

    }
   
}
