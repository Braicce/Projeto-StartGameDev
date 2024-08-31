using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Player player;
    private Animator anim;
    private Fishing fishing;

    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        fishing = FindObjectOfType<Fishing>();
    }

   
    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement
    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if(player.isRolling){
                anim.SetTrigger("rolling");
            }
            else{
                anim.SetInteger("transition", 1);
            }
        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (player.isCutting) //true
        {
            anim.SetInteger("transition", 3);
        }

        if (player.isDigging) //true
        {
            anim.SetInteger("transition", 4);
        }

        if (player.isWatering) //true
        {
            anim.SetInteger("transition", 5);
        }
    }
    void OnRun()
    {
        if (player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }
    }






    #endregion
    public void OnCastingStarted()
    {
        anim.SetTrigger("isCasting");
        player.isPaused = true;
    }

    public void OnCastingEnded()
    {
        fishing.OnFishing();
        player.isPaused = false;
    }
}
