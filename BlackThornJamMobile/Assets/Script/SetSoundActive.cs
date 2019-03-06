using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SetSoundActive : MonoBehaviour
{
    public GameObject music;
    // Start is called before the first frame update
    void Start()
    {
        music.SetActive(LoadOptions().soundActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Options LoadOptions()
    {
        using (StreamReader streamReader = File.OpenText(Path.Combine(Application.persistentDataPath, "Options.txt")))
        {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<Options>(jsonString);
        }
    }
    public void PlaySound(AudioSource son)
    {
        if (LoadOptions().soundActive)
        {
            son.Play();
        }
    }
}
