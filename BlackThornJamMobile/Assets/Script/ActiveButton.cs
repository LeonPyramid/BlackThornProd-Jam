﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButton : MonoBehaviour
{
    public GameObject[] bouttons;
    public AudioSource boutonSon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActiveButtons()
    {
        if (FindObjectOfType<SetSoundActive>().LoadOptions().soundActive)
        {
            boutonSon.Play();
        }
        int count = 1;
        foreach(GameObject bout in bouttons)
        {
            bout.SetActive(FindObjectOfType<GlobalVar>().dispoTool.dispoTools[count]);
            count += 1;
        }
    }
}
