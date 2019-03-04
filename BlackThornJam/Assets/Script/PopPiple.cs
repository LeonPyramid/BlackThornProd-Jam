using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopPiple : MonoBehaviour
{
    public bool changeable;
    private Sprite well;
    private Sprite bad;
    public bool State;
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
                GetComponent<BubleShow>().active = false;

            }
            else
            {
                GetComponent<BubleShow>().active = true;
            }
        }
        else
        {
            State = true;
            GetComponent<BubleShow>().active = true;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (changeable)
        {
            if (global.socialg < 3 && State && global.socialg != 0)
            {
                StartCoroutine(ChangeSprite(bad));
                GetComponent<BubleShow>().active = false;
                State = false;
            }
            else if (!State && global.socialg > 2 && global.socialg != 0)
            {
                StartCoroutine(ChangeSprite(well));
                GetComponent<BubleShow>().active = true;
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
