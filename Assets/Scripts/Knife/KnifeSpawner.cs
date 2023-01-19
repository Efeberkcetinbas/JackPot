using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class KnifeSpawner : MonoBehaviour
{
    public Transform shootPoint;


    bool canUp;

    private GameManager gameManager;

    private void Start()
    {
        gameManager=GameManager.Instance;
    }

    void Update()
    {
        if(!gameManager.isGameEnd)
        {
            if(Input.touchCount>0)
            {
                Touch touch=Input.GetTouch(0);

                if(touch.phase==TouchPhase.Began)
                {
                    CubePooler.Instance.SpawnFromPool("Knife",shootPoint.position,shootPoint.rotation);
                    canUp=true;
                    gameManager.StartCoroutine(gameManager.CallCubeManager());
                }
            }

            if(canUp)
            {
                SetY();
                canUp=false;
            }
        }
    }
    
    private void SetY()
    {
        gameManager.y+=1f;
        shootPoint.transform.DOLocalMoveY(gameManager.y,0.1f);
        //shootPoint.position = new Vector3(shootPoint.position.x, y, shootPoint.position.z);
    }

    
}
