﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopPiple : MonoBehaviour
{
    public bool changeable;
    private Sprite well;
    private Sprite bad;
    private bool State;
    public GameObject bubble;
    private GlobalVar global;
    private SpriteRenderer spriteR;
    // Start is called before the first frame update
    void Start()
    {
        if (changeable)
        {
            spriteR = GetComponent<SpriteRenderer>();
                    global = FindObjectOfType<GlobalVar>();
                    well = spriteR.sprite;
                    bad = null;
                    State = true;
                    spriteR.sprite = well;

                    if (global.socialBasic < 3)
                    {
                        State = false;
                        spriteR.sprite = bad;
                        bubble.SetActive(false);
                    }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
     if (changeable)
        {
            if (global.socialg < 3 && State && global.socialg != 0)
                    {
                        StartCoroutine(ChangeSprite(bad,false));
                        State = false;
                    }
                    else if (!State && global.socialg > 2 && global.socialg != 0)
                    {
                        StartCoroutine(ChangeSprite(well,true));
                        State = true;
                    }
        }  
        
        
    }
    public IEnumerator ChangeSprite(Sprite sprite, bool bo)
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        spriteR.sprite = sprite;
        bubble.SetActive(bo);
    }

}
