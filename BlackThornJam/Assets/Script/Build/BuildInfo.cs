using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInfo : MonoBehaviour
{
    public int social;
    public int ecologie;
    public int argent;
    public int id;
    private GameObject choiceMenu;
    void Start()
    {
        choiceMenu = GameObject.FindGameObjectWithTag("ChoiceMenu");
    }
    public void OnMouseDown()
    {
        choiceMenu.SetActive(true);
        choiceMenu.GetComponent<BuildNumber>().build = this.gameObject;
    }
}
