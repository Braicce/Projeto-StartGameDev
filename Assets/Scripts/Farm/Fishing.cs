using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [SerializeField] private int percentage; //porcentagem de chance de pescar
    [SerializeField] private GameObject fishPrefab;

    [SerializeField] private bool detectingPlayer;
    private PlayerItens player;
    private PlayerAnimation playerAnimation;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerItens>();
        playerAnimation = player.GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerAnimation.OnCastingStarted();
        }
    }

    public void OnFishing()
    {
        int randomValue = Random.Range(1, 100);

        if(randomValue <= percentage) 
        {
            Instantiate(fishPrefab, player.transform.position + new Vector3(0, Random.Range(1f, 2f), 0f), Quaternion.identity);
            //conseguiu pescar peixe            
        } else
        {
            Debug.Log("Nao pescou");
            //falhou pescar            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
