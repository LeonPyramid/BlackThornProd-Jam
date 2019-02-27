using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubleShow : MonoBehaviour
{
    public GameObject bubble;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        bubble.SetActive(false);
    }

    private void OnMouseEnter()
    {
        if (active)
        {
            bubble.SetActive(true);
        }
        
    }
    private void OnMouseExit()
    {
        bubble.SetActive(false);
    }
}
