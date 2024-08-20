using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float dialogueRange; //tamanho do colisor
    public LayerMask playerLayer; //colisor do player

    public DialogueSettings dialogue; 

    bool playerHit;

    private List<string> sentences = new List<string>();

    private void Start()
    {
        GetNPCInfo();
    }
    
    void LoadCanva()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            Debug.Log("TECLOU E");
            DialogueControl.instance.dialogueObj.SetActive(true);
            DialogueControl.instance.Speech(sentences.ToArray());
        }

    }

    void Update()
    {
        LoadCanva();
    }

    void GetNPCInfo() 
    {
        for(int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DialogueControl.instance.language)
            {
                case DialogueControl.idioma.ptbr:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;

                case DialogueControl.idioma.eng:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;

                case DialogueControl.idioma.spa:
                    sentences.Add(dialogue.dialogues[i].sentence.spanish);
                    break;
            }          
        }
    }

    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null)
        {
            playerHit = true;
        } 
        else
        {
            playerHit = false;
            DialogueControl.instance.dialogueObj.SetActive(false);
        }
    }
        private void OnDrawGizmosSelected()
            {
                Gizmos.DrawWireSphere(transform.position, dialogueRange);
            }
}
