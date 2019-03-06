using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildInfo : MonoBehaviour
{
    public int social;
    public int ecologie;
    public int argent;
    public int id;
    public GameObject choiceMenu;
    public float timecop;
    void Start()
    {
        choiceMenu = FindObjectOfType<MenuForPiple>().menu;
    }
    public void OnMouseDown()
    {
        if (!choiceMenu.active&& !IsPointerOverUIObject())
        {
            if(FindObjectOfType<SetSoundActive>().LoadOptions().soundActive)
            {
                GetComponent<AudioSource>().Play();
            }
            StartCoroutine(launchDelay());
        }
       
    }
    public IEnumerator launchDelay()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        choiceMenu.SetActive(true);
        choiceMenu.GetComponent<BuildNumber>().build = this.gameObject;
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
