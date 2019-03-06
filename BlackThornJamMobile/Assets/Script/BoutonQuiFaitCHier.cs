using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonQuiFaitCHier : MonoBehaviour
{
    public AudioSource son;
    public void Caca()
    {
        FindObjectOfType<DialogManager>().DisplayNextSentence();
        if (FindObjectOfType<SetSoundActive>().LoadOptions().soundActive)
        {
            son.Play();
        }
    }
}
