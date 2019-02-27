using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{

    public Dialog dialog;
    public Dialog dialogWin;
    private Dialog randDialogList;
    public Dialog randDialog;
    private int random;
    public GameObject menu;
    private GlobalVar global;
    private void Start()
    {
        menu = FindObjectOfType<MenuForPiple>().menu;
        global = FindObjectOfType<GlobalVar>();
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
                if (global.win)
                {
                    TriggerDialog(dialogWin);
                }
                else
                {
                    TriggerDialog(dialog);
                }
                
            }
        }
        

    }
    public void TriggerDialog(Dialog dialog)
    {
        Debug.Log(dialog);
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }
}
