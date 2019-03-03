using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TutoDialog : MonoBehaviour
{
    public Dialog dialog;
    public TutoStat tutoStat;
    public bool forcetuto;
    public int tutotVar;
    // Start is called before the first frame update
    void Update()
    {
        if (load().stat == tutotVar||forcetuto)
        {
            forcetuto = false;
            tutoStat.stat = tutotVar+1;
            SaveTuto();
            StartCoroutine(go());
        }
    }


    public TutoStat load()
    {
        using (StreamReader streamReader = File.OpenText(Path.Combine(Application.persistentDataPath, "Tuto.txt")))
        {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<TutoStat>(jsonString);
        }
    }
    public void SaveTuto()
    {
        string json = JsonUtility.ToJson(tutoStat);
        using (StreamWriter str = File.CreateText(Path.Combine(Application.persistentDataPath, "Tuto.txt")))
        {
            str.Write(json);
        }
    }
    public IEnumerator go()
    {

        yield return new WaitForSeconds(0.1f);
        this.GetComponent<DialogManager>().StartDialog(dialog);
    }
}
