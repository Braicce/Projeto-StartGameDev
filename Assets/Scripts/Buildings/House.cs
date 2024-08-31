using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float timeAmount;
    [SerializeField] private int woodAmount;

    [Header("Components")]
    [SerializeField] private GameObject houseColisor;
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private Transform point;

    
    private bool detectingPlayer;
    private Player player;    
    private PlayerAnimation playerAnim;
    private PlayerItens playerItens;

    private float timeCount;
    private bool isBegining;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        playerItens = player.GetComponent<PlayerItens>();
        playerAnim = player.GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E) && playerItens.totalWood >= woodAmount)
        {
            //começa construir
            isBegining = true;
            playerAnim.OnHammeringStart();
            houseSprite.color = startColor;
            player.transform.position = point.position;
            player.isPaused = true;
            playerItens.totalWood -= woodAmount;
        }

        if (isBegining)
        {
            timeCount += Time.deltaTime;

            if(timeCount >= timeAmount)
            {
                //casa pronta
                playerAnim.OnHammeringEnd();
                houseSprite.color = endColor;
                player.isPaused = false;
                houseColisor.SetActive(true);
            }
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
