using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildNumber : MonoBehaviour
{
    public GameObject build;
    public bool run;
    private GameObject[] bouttons;
    private DisponibleTool tamp;
    private int count;
    private bool first;
    void Start()
    {
        bouttons = GameObject.FindGameObjectsWithTag("Boutton");
        first = true;
    }

    void Update()
    {
        if (run)
        {
            run = false;
            StartCoroutine(waitTime());

        }
        if (FindObjectOfType<GlobalVar>().win&&first)
        {
            first = false;
            foreach (GameObject boutton in bouttons)
            {
                boutton.SetActive(true);
            }
            count = 1;
            foreach (GameObject boutton in bouttons)
            {
                Debug.Log(count);
                GameObject.Find("Button (" + count.ToString() + ")").SetActive(FindObjectOfType<GlobalVar>().dispoTool.dispoTools[count]);
                count += 1;
            }
            tamp = FindObjectOfType<GlobalVar>().dispoTool;
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
    public void Close()
    {
        this.gameObject.SetActive(false);
    }

}
