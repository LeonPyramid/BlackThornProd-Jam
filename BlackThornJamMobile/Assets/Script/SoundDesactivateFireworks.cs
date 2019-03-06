using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDesactivateFireworks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<SetSoundActive>().LoadOptions().soundActive)
        {
            GetComponent<AudioSource>().Play();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
