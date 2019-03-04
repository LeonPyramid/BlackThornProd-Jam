using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBuild : MonoBehaviour
{
    public int param;
    private GameObject choiceMenu;
    public AudioSource m_DestructStream;
    public AudioSource m_ConstructStream;
    void Start()
    {
        choiceMenu = GameObject.FindGameObjectWithTag("ChoiceMenu");
    }

    public void Change()
    {
        choiceMenu.GetComponent<BuildNumber>().build.GetComponent<BuildChangement>().ChangeInfo(param);
        choiceMenu.SetActive(false);
        if (param == 0)
        {
            m_DestructStream.Play();
        }
        else
        {
            m_ConstructStream.Play();
        }
            }
}
