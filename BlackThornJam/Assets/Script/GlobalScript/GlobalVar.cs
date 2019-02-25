using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVar : MonoBehaviour
{

    public float plantetHeigh;
    public int socialBasic;
    public int ecologieBasic;
    public int argentBasic;
    private int social;
    private int ecologie;
    private int argent;
    private GameObject[] buildable;
    private GameObject choiceMenu;
    public bool[] choiceMenuActivation;
    private GameObject[] choiceMenuBoutton;
    private int count = 1;
    void Start()
    {
        buildable = GameObject.FindGameObjectsWithTag("Buildable");
        choiceMenu = GameObject.FindGameObjectWithTag("ChoiceMenu");
        choiceMenuBoutton = GameObject.FindGameObjectsWithTag("Boutton");
        foreach(GameObject boutton in choiceMenuBoutton)
        {
            boutton.SetActive(choiceMenuActivation[count]);
            count += 1;
        }
        choiceMenu.SetActive(false);
    }
    void Update()
    {
        social = socialBasic;
        argent = argentBasic;
        ecologie = ecologieBasic;
        foreach(GameObject build in buildable)
        {
            social += build.GetComponent<BuildInfo>().social;
            argent += build.GetComponent<BuildInfo>().argent;
            ecologie += build.GetComponent<BuildInfo>().ecologie;
        }
    }
}
