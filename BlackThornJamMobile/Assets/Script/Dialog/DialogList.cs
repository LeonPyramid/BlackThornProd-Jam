using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogList : MonoBehaviour
{
    private GlobalVar global;
    public Dialog socialBas;
    public Dialog ecoBas;
    public Dialog argentBas;
    public Dialog toutOk;
    private int random;
    // Start is called before the first frame update
    void Start()
    {
        global = FindObjectOfType<GlobalVar>();
    }
    void Update()
    {
        random = (int)Random.Range(1, 4);
    }
    public Dialog DialogChoice()
    {
        if (global.win)
        {
            return toutOk;
        }
        if (random == 1 && global.socialg < 3)
        {
            return socialBas;
        }
        if (random == 2 && global.argentg < 3)
        {
            return argentBas;
        }
        if (random == 3 && global.ecologieg < 3)
        {
            return ecoBas;
        }
        if (random == 3)
        {
            random =1;
        }
        else
        {
            random += 1;
        }
        return DialogChoice();
    }
}
