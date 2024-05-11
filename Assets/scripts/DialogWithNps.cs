using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogWithNps : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private GameObject dialogLetter;
    [SerializeField]
    private GameObject[] dialogs;
    [SerializeField]
    private GameObject dialogPanel;
    [SerializeField]
    private GameObject nextButton;
    [SerializeField]
    private bool isCanDialog = false;

    private int i = 0;

    void Update()
    {
        if(i == dialogs.Length)
        {
            dialogs[i-1].SetActive(false);
            dialogPanel.SetActive(false);
            nextButton.SetActive(false);
        }
        if(i>=1 && i != dialogs.Length)
        {
            dialogs[i-1].SetActive(false);
            dialogs[i].SetActive(true);
            player.DialogIsFinished();
        }

        ShowDialog();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogLetter.SetActive(true);
            print("letter");
            isCanDialog = true;

        }
        else
        {
            dialogLetter.SetActive(false);
            isCanDialog = false;
        }
    }

    public void ShowDialog()
    {
        if(player.ShowDialog() == true && isCanDialog == true)
        {
            i = 0; 
            print("showdialog");
            dialogLetter.SetActive(false);
            dialogPanel.SetActive(true);
            dialogs[0].SetActive(true);
            nextButton.SetActive(true);
        }
    }

    public void Next()
    {
        i += 1;
    }


}
