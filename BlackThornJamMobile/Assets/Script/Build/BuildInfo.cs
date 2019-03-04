using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInfo : MonoBehaviour
{
    public int social;
    public int ecologie;
    public int argent;
    public int id;
    public GameObject choiceMenu;
    public float timecop;
    void Start()
    {
        choiceMenu = FindObjectOfType<MenuForPiple>().menu;
    }
    public void OnMouseDown()
    {
        if (!choiceMenu.active)
        {
            GetComponent<AudioSource>().Play();
            StartCoroutine(launchDelay());
        }
       
    }
    public IEnumerator launchDelay()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        choiceMenu.SetActive(true);
        choiceMenu.GetComponent<BuildNumber>().build = this.gameObject;
    }

}
