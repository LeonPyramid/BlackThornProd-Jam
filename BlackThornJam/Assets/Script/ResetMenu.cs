using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class ResetMenu : MonoBehaviour
{
    public GameObject Panel;
    private string path;
    public GameObject panelFinal;
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
        panelFinal.SetActive(false);
        path= Path.Combine(Application.persistentDataPath, "Test.txt");
    }

    // Update is called once per frame

    public void PanelShow()
    {
        Panel.SetActive(true);
    }
    public void No()
    {
        Panel.SetActive(false);
        panelFinal.SetActive(false);
    }
    public void Yes()
    {
        File.Delete(path);
        Panel.SetActive(false);
        panelFinal.SetActive(true);
    }
}
