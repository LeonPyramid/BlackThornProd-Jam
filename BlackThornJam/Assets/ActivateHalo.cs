using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHalo : MonoBehaviour
{
    public GameObject halo;
    // Start is called before the first frame update
    void Start()
    {
        halo.SetActive(false);
    }

    private void OnMouseEnter()
    {
        halo.SetActive(true);
    }
    private void OnMouseExit()
    {
        halo.SetActive(false);
    }
}
