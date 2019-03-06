using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildCount : MonoBehaviour
{
    public Text x;
    public Text y;
    private int countx;
    private int county;
    public GameObject Check;
    // Start is called before the first frame update
    void Start()
    {
        county = 0;
        foreach(GameObject build in GameObject.FindGameObjectsWithTag("Buildable"))
        {
            county += 1;
        }
        y.text = county.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        countx = 0;
        foreach (GameObject build in GameObject.FindGameObjectsWithTag("Buildable"))
        {
            if(build.GetComponent<BuildInfo>().id != 0)
            {
                countx += 1;
            }
        }
        x.text = countx.ToString();
        Check.SetActive(FindObjectOfType<GlobalVar>().win);
    }
}
