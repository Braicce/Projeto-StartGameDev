using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idioma //selecionar idioma do jogo
    {
        ptbr,
        eng,
        spa
    }

    public idioma language;


    [Header("Components")]
    public GameObject dialogueObj; //janela do dialogo
    public Image profileSprite; //sprite do perfil 
    public Text speechText; //texto fala
    public Text actorNameText; //nome do npc

    [Header("Settings")]
    public float typingSpeed; //velocidade da fala

    //Variaveis de Controle
    public bool isShowing; //saber se a janela esta visivel
    private int index; //inicio do array
    private string[] sentences;


    public static DialogueControl instance; //instanciando a classe pra poder usar no npc dialogue
    private void Awake() // é chamado antes de todos os starts na hierarquia dos scripts
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray()) //variavel letter tipo char pra armazenar 1 caracter e vai rodar até terminar a frase
        {
                    speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //pular pra proxima frase
    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            } //termina os textos
            else
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }
    //chamar a fala do npc
    public void Speech(string[] txt) 
    {
        if (!isShowing)
            {
                dialogueObj.SetActive(true);
                Debug.Log("PASSOU O TEXTO");
                sentences = txt;
                StartCoroutine(TypeSentence());
                isShowing = true;
              }
    }

}
