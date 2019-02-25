using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildChangement : MonoBehaviour
{
    private BuildInfo info;
    private ObjetList list;
    // Start is called before the first frame update
    void Start()
    {
        info = GetComponent<BuildInfo>();
        list = GameObject.FindGameObjectWithTag("Info").GetComponent<ObjetList>();

    }

    public void ChangeInfo(int param)
    {
        info.social = list.socialList[param];
        info.argent = list.argentList[param];
        info.ecologie = list.ecologieList[param];
        GetComponent<SpriteRenderer>().sprite = list.imageList[param];
        info.id = param;
    }

}
