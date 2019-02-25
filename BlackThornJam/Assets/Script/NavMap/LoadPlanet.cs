using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlanet : MonoBehaviour
{
    public int planetNum;
    private string planetName;
    // Start is called before the first frame update
    void Start()
    {
        planetName = "Planet" + planetNum.ToString();
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(planetName);
    }
}
