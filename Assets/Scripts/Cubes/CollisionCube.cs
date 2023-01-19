using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollisionCube : Obstacleable
{
    private UIManager uIManager;
    private GameManager gameManager;

    private void Start()
    {
        uIManager=UIManager.Instance;
        gameManager=GameManager.Instance;
    }
    public CollisionCube()
    {
        interactionTag="Knife";
    }
    
    internal override void DoAction(Player player)
    {
        if(player.GetComponent<KnifeMove>().canDamage)
        {
            player.GetComponent<KnifeMove>().speed=0;
            transform.GetComponent<MovementCube>().KillTween();
            DoScale();
            gameManager.HitTarget++;
            uIManager.UpdateProgressBar((float)gameManager.HitTarget/(float)gameManager.AmounOfCube,0.5f);
            Debug.Log("HIT THE TARGET");

            if(gameManager.AmounOfCube==gameManager.HitTarget)
            {
                gameManager.isGameEnd=true;
                Debug.Log("SUCCESSSS");
            }
            //Puan da vericeksin burada
        }
    }

    private void DoScale()
    {
        transform.DOScaleY(1,0.2f).OnComplete(()=>transform.DOScaleY(0.5f,0.2f));
    }
}
