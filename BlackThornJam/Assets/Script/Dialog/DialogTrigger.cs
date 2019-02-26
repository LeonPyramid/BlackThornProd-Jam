using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{

    public Dialog dialog;
    private Dialog randDialogList;
    public Dialog randDialog;
    private int random;
    public GameObject menu;
    private void Start()
    {
        menu = FindObjectOfType<MenuForPiple>().menu;
    }
    public void OnMouseDown()
    {
        if (!menu.active)
        {
            if (dialog.dialog.Length == 0)
            {
                randDialogList = FindObjectOfType<DialogList>().DialogChoice();
                random = Random.Range(0, randDialogList.dialog.Length);
                randDialog.dialog[0] = randDialogList.dialog[random];
                TriggerDialog(randDialog);
            }
            else
            {
                TriggerDialog(dialog);
            }
        }
        

    }
    public void TriggerDialog(Dialog dialog)
    {
        Debug.Log(dialog);
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }
}
