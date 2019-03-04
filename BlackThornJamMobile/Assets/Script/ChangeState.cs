﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour
{
    public Sprite well;
    public Sprite bad;
    private bool State;
    private GlobalVar global;
    private SpriteRenderer spriteR;
    public enum factor { argent, ecologie };
    public factor fact;
    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        global = FindObjectOfType<GlobalVar>();
        State = true;
        spriteR.sprite = well;

        if (global.ecologieBasic < 3 && fact == factor.ecologie)
        {
            State = false;
            spriteR.sprite = bad;
        }
        if (global.argentBasic < 3 && fact == factor.argent)
        {
            State = false;
            spriteR.sprite = bad;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (fact == factor.ecologie)
        {
            if (global.ecologieg < 3 && State && global.ecologieg != 0)
            {
                StartCoroutine(ChangeSprite(bad));
                State = false;
            }
            else if (!State && global.ecologieg > 2 && global.ecologieg != 0)
            {
                StartCoroutine(ChangeSprite(well));
                State = true;
            }
        }
        else if (fact == factor.argent)
        {
            if (global.argentg < 3 && State && global.argentg != 0)
            {
                StartCoroutine(ChangeSprite(bad));
                State = false;
            }
            else if (!State && global.argentg > 2 && global.argentg != 0)
            {
                StartCoroutine(ChangeSprite(well));
                State = true;
            }
        }

    }
    public IEnumerator ChangeSprite(Sprite sprite)
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        spriteR.sprite = sprite;

    }
}
