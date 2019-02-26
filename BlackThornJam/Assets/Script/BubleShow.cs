using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubleShow : MonoBehaviour
{
    public GameObject bubble;
    // Start is called before the first frame update
    void Start()
    {
        bubble.SetActive(false);
    }

    private void OnMouseEnter()
    {
        bubble.SetActive(true);
    }
    private void OnMouseExit()
    {
        bubble.SetActive(false);
    }
}
