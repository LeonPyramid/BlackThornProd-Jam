using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildNumber : MonoBehaviour
{
    public GameObject build;
    public bool run;
    private GameObject[] bouttons;

    void Start()
    {
        bouttons = GameObject.FindGameObjectsWithTag("Boutton");
    }

    void Update()
    {
        if (run)
        {
            run = false;
            StartCoroutine(waitTime());

        }
    }
    public IEnumerator waitTime()
    {
        foreach (GameObject bout in bouttons)
        {
            bout.GetComponent<Button>().interactable = false;

        }
        yield return new WaitForSecondsRealtime(0.05f);
        foreach (GameObject bout in bouttons)
        {
            bout.GetComponent<Button>().interactable = true;
        }
    }

}
