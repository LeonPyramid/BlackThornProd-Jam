using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPages : MonoBehaviour
{
    public GameObject[] pages;
    public GameObject pageRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenPage()
    {
        foreach(GameObject page in pages)
        {
            page.SetActive(false);
        }
        pageRef.SetActive(true);
    }
}
