using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatChange : MonoBehaviour
{
    public Sprite well;
    public Sprite bad;
    private bool State;
    private bool temp;
    private SpriteRenderer spriteR;
    private GameObject[] buildable;
    public int buildId;
    private Sprite get;
    // Start is called before the first frame update
    void Start()
    {
        buildable = GameObject.FindGameObjectsWithTag("Buildable");
        spriteR = GetComponent<SpriteRenderer>();
        State = false;
        temp = false;
        get = bad;
        foreach(GameObject build in buildable)
        {
            if (build.GetComponent<BuildInfo>().id == buildId)
            {
                State = true;
                get = well;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        State = false;
        get = bad;
        foreach (GameObject build in buildable)
        {
            if (build.GetComponent<BuildInfo>().id == buildId)
            {
                State = true;
                get = null;
            }
        }
        if(temp!= State)
        {
            StartCoroutine(ChangeSprite(get));
            temp = State;
        }
        StartCoroutine(ChangeSprite(get));
    }
    public IEnumerator ChangeSprite(Sprite sprite)
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        spriteR.sprite = sprite;

    }
}
