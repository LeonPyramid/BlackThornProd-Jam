using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogTrigger : MonoBehaviour
{

    public Dialog dialog;
    public Dialog dialogWin;
    private Dialog randDialogList;
    public Dialog randDialog;
    private int random;
    public GameObject menu;
    private GlobalVar global;
    public AudioSource son;
    private void Start()
    {
        menu = FindObjectOfType<MenuForPiple>().menu;
        global = FindObjectOfType<GlobalVar>();
    }
    public void OnMouseDown()
    {
        if (!menu.active&&GetComponent<PopPiple>().State&&!IsPointerOverUIObject())
        {

            if(FindObjectOfType<SetSoundActive>().LoadOptions().soundActive)
            {
                son.Play();
            }
            if (global.win)
            {
                
                if (dialogWin.dialog.Length == 0)
                {
                    randDialogList = FindObjectOfType<DialogList>().DialogChoice();
                    random = Random.Range(0, randDialogList.dialog.Length);
                    randDialog.dialog[0] = randDialogList.dialog[random];
                    TriggerDialog(randDialog);
                }
                else
                {
                    TriggerDialog(dialogWin);
                }
            }
            else
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
        

    }
    public void TriggerDialog(Dialog dialog)
    {
        Debug.Log(dialog);
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
