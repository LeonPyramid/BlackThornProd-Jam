using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCredit : MonoBehaviour
{
    public GameObject halo;
    public GameObject credit;
    void Start()
    {
        halo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        halo.SetActive(true);
    }
    private void OnMouseExit()
    {
        halo.SetActive(false);
    }
    private void OnMouseDown()
    {
        credit.SetActive(true);
    }
}
