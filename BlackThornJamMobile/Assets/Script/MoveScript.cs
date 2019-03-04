using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public bool move=false;    // Start is called before the first frame update

    public void OnPointerDown()
    {
        move = true;
    }

    public void OnPointerUp()
    {
        move = false;
    }
}
