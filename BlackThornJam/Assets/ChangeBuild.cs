using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBuild : MonoBehaviour
{
    public int param;
    private GameObject choiceMenu;
    void Start()
    {
        choiceMenu = GameObject.FindGameObjectWithTag("ChoiceMenu");
    }

    public void Change()
    {
        choiceMenu.GetComponent<BuildNumber>().build.GetComponent<BuildChangement>().ChangeInfo(param);
        choiceMenu.SetActive(false);
    }
}
