using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class OptionSaver : MonoBehaviour
{
    public Options options;
    public AudioSource musicPlayer;
    public bool changeable;
    // Start is called before the first frame update
    void Start()
    {
        changeable = false;
        if(!File.Exists(Path.Combine(Application.persistentDataPath, "Options.txt")))
        {
            options.soundActive = true;
            SaveOption();
        }
        options = LoadOptions();
        GetComponent<Toggle>().isOn = options.soundActive;
        changeable = true;
        if (options.soundActive)
        {
            musicPlayer.Play();
        }
        else
        {
            musicPlayer.Pause();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeSoudState()
    {
        if(changeable)
        {
            options.soundActive = !options.soundActive;
            SaveOption();
        }
        if (options.soundActive)
        {
            GetComponent<AudioSource>().Play();
            Debug.Log(options.soundActive);
            musicPlayer.Play();
        }
        else
        {
            musicPlayer.Pause();
        }
    }
    public void SaveOption()
    {
        string json = JsonUtility.ToJson(options);
        using (StreamWriter str = File.CreateText(Path.Combine(Application.persistentDataPath, "Options.txt")))
        {
            str.Write(json);
        }
    }
    public Options LoadOptions()
    {
        using (StreamReader streamReader = File.OpenText(Path.Combine(Application.persistentDataPath, "Options.txt")))
        {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<Options>(jsonString);
        }
    }
}
