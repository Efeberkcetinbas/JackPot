using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollisionCube : Obstacleable
{
    private UIManager uIManager;
    private GameManager gameManager;
    private ScoreManager scoreManager;
    private CameraManager cameraManager;
    
    public int increaseScore;

    private void Start()
    {
        uIManager=UIManager.Instance;
        gameManager=GameManager.Instance;
        scoreManager=ScoreManager.Instance;
        cameraManager=CameraManager.Instance;
    }
    public CollisionCube()
    {
        interactionTag="Knife";
    }
    
    internal override void DoAction(Player player)
    {
        if(player.GetComponent<KnifeMove>().canDamage && !gameManager.isGameEnd)
        {
            player.GetComponent<KnifeMove>().speed=0;
            transform.GetComponent<MovementCube>().KillTween();
            transform.GetComponent<MoneyEffect>().StartCoinMove(transform.position,transform.gameObject);
            DoScale();
            scoreManager.UpdateScore(increaseScore);
            cameraManager.ShakeIt();
            gameManager.HitTarget++;
            uIManager.UpdateProgressBar((float)gameManager.HitTarget/(float)gameManager.AmounOfCube,0.5f);
            Debug.Log("HIT THE TARGET");


            if(gameManager.AmounOfCube==gameManager.HitTarget)
            {
                gameManager.isGameEnd=true;
                Debug.Log("SUCCESSSS");
            }
        }
    }

    private void DoScale()
    {
        transform.DOScaleY(0.75f,0.2f).OnComplete(()=>transform.DOScaleY(0.5f,0.2f));
    }

    public void UpdateRangeScore()
    {
        increaseScore=Random.Range(0,20);
    }
}
