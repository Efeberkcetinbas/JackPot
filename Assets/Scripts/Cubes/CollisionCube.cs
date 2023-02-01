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
    private SoundManager soundManager;
    private LevelManager levelManager;
    public int increaseScore;

    [SerializeField] private Transform target;

    [SerializeField] private ParticleSystem dustEffect;

    private void Start()
    {
        uIManager=UIManager.Instance;
        gameManager=GameManager.Instance;
        scoreManager=ScoreManager.Instance;
        cameraManager=CameraManager.Instance;
        soundManager=SoundManager.Instance;
        levelManager=LevelManager.Instance;
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
            DoScale();
            TargetScore(player.transform);
            scoreManager.UpdateScore(increaseScore);
            transform.GetComponent<MoneyEffect>().StartCoinMove(transform.position,transform.gameObject);
            cameraManager.ShakeIt();
            soundManager.Play("Hit");
            gameManager.HitTarget++;
            dustEffect.Play();
            //gameManager.PlayViewerAnimation();
            uIManager.UpdateProgressBar((float)gameManager.HitTarget/(float)gameManager.AmounOfCube,0.5f);
            Debug.Log("HIT THE TARGET");
            

            if(gameManager.AmounOfCube==gameManager.HitTarget)
            {
                gameManager.isGameEnd=true;
                StartCoroutine(LoadNext());
                Debug.Log("SUCCESSSS");
            }
        }
    }

    private void DoScale()
    {
        transform.DOScaleY(0.4f,0.2f).OnComplete(()=>transform.DOScaleY(0.5f,0.2f));
    }

    private IEnumerator LoadNext()
    {
        yield return new WaitForSeconds(1);
        levelManager.LoadNextLevel();

    }

    public void UpdateRangeScore()
    {
        //increaseScore=Random.Range(1,20);
    }

    private void TargetScore(Transform knife)
    {
        float distance=Mathf.Abs(target.position.x-knife.position.x);
        Debug.Log(distance);

        if(distance<0.05f)
            increaseScore=50;

        else if(distance<0.3f)
            increaseScore=25;
            
        else if(distance<0.6f)
            increaseScore=10;
            

        
        
        //50-25-10
    }
}
